using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TSSN.FTE.Insurance.Domain;
using TSSN.FTE.Insurance.DTO;
using TSSN.FTE.Insurance.Service.Contracts;
using TSSN.FTE.Insurance.Web.Common;
using TSSN.FTE.Insurance.Web.Helpers;
using TSSN.Utility;

namespace TSSN.FTE.Insurance.Web.Controllers
{
    public partial class DocumentController : Controller
    {

        // GET: FileUpload
        #region Fields
        private readonly IDocumentService _documentService;
        FilesHelper filesHelper;

        string deleteURL = "/Document/Delete?documentId=";
        string downloadURL = "/Document/Download?documentId=";
        string deleteType = "GET";

        #endregion

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
            filesHelper = new FilesHelper(deleteURL, deleteType, downloadURL);

            if (SessionBag.Current.DocumentIdList == null) SessionBag.Current.DocumentIdList = new List<long>();
        }

        [HttpPost]
        public virtual async Task<JsonResult> CreateTransDocument()
        {
            SessionBag.Current.DocumentIdList = new List<long>();

            var result = await createDocument(DocumentTypesEnum.TransDocument);

            JsonFiles files = new JsonFiles(result);

            bool isEmpty = !result.Any();

            if (isEmpty)
            {
                return new JsonResult
                {
                    Data = new
                    {
                        success = false
                    }
                };
            }
            else
            {
                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        data = files
                    }
                };
            }
        }

        [HttpGet]
        public virtual FileResult DownloadPDF(int transId)
        {
            var file = _documentService.GetTransDocumentContent(transId);
            return File(file.Content, "application/pdf");
        }

        public virtual async Task<JsonResult> GetTransDocumentDetail(int transId)
        {
            var docDetail = await _documentService.GetTransDocumentDetail(transId);

            if (docDetail == null)
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

            return Json(new { success = true, result = docDetail }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public virtual async Task<JsonResult> DeleteDocument(long transId)
        {
            await _documentService.Delete(transId);
            return new JsonResult
            {
                Data = new
                {
                    success = false
                }
            };
        }

        #region Private Methods
        private async Task<List<ViewDataUploadFilesResult>> createDocument(DocumentTypesEnum documentType)
        {
            var request = HttpContext.Request;
            var headers = request.Headers;
            var resultList = new List<ViewDataUploadFilesResult>();

            for (int i = 0; i < request.Files.Count; i++)
            {
                var file = request.Files[i];

                var model = new CreateDocumentDto()
                {
                    FileName = file.FileName,
                    FileType = documentType,
                    ContentType = file.ContentType,
                    Content = file.InputStream.ConvertToByteArrary(file.ContentLength),
                    IsTemp = true
                };

                //Create thumb
                string[] imageArray = request.Files[i].FileName.Split('.');
                if (imageArray.Length != 0)
                {
                    string extansion = imageArray[imageArray.Length - 1];
                    if (extansion.ToLower() == "jpg" && extansion.ToLower() == "png") //Do not create thumb if file is not an image
                    {
                        var thumbnail = new WebImage(model.Content).Resize(80, 80);
                        model.ThumbnailImage = thumbnail.GetBytes();
                    }
                }

                var documentId = await _documentService.CreateTransDocument(model);
                SessionBag.Current.DocumentIdList.Add(documentId);

                var result = filesHelper.UploadResult(file.FileName, file.ContentLength, documentId);
                result.thumbnailUrl = filesHelper.CheckThumb(file.ContentType, file.FileName, model.ThumbnailImage);
                resultList.Add(result);
            }
            return resultList;
        }
        #endregion
    }
}