using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSSN.Utility;

namespace TSSN.FTE.Insurance.Web.Helpers
{
    public class FilesHelper
    {
        string deleteURL = null;
        string deleteType = null;
        string downloadURL = null;
        
        static readonly string[] SizeSuffixes =
                   { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public FilesHelper()
        {

        }

        public FilesHelper(string deleteURL, string deleteType
            , string downloadURL/*, IFileService fileService, IUnitOfWork unitOfWork*/)
        {
            this.deleteURL = deleteURL;
            this.deleteType = deleteType;
            this.downloadURL = downloadURL;
            
        }
        
        public void UploadAndShowResults(HttpContextBase ContentBase, List<ViewDataUploadFilesResult> resultList)
        {
            var httpRequest = ContentBase.Request;

            foreach (string inputTagName in httpRequest.Files)
            {
                var headers = httpRequest.Headers;

                var file = httpRequest.Files[inputTagName];
                System.Diagnostics.Debug.WriteLine(file.FileName);

                if (string.IsNullOrEmpty(headers["X-File-Name"]))
                {
                    UploadWholeFile(ContentBase, resultList);
                }
                else
                {
                    //UploadPartialFile(headers["X-File-Name"], ContentBase, resultList);
                }
            }
        }
        
        private void UploadWholeFile(HttpContextBase requestContext, List<ViewDataUploadFilesResult> statuses)
        {
            //var request = requestContext.Request;
            //for (int i = 0; i < request.Files.Count; i++)
            //{
            //    var file = request.Files[i];

            //    var fileViewModel = new SaveFileInput
            //    {
            //        FileName = file.FileName,
            //        FileType = DocumentTypesEnum.MessageAttachment,
            //        ContentType = file.ContentType,
            //        Content = file.InputStream.ConvertToByteArrary(file.ContentLength),
            //        IsTemp = true
            //    };
                
            //    //Create thumb
            //    string[] imageArray = request.Files[i].FileName.Split('.');
            //    if (imageArray.Length != 0)
            //    {
            //        String extansion = imageArray[imageArray.Length - 1];
            //        if (extansion.ToLower() == "jpg" && extansion.ToLower() == "png") //Do not create thumb if file is not an image
            //        {
            //            var thumbnail = new WebImage(fileViewModel.Content).Resize(80, 80);
            //            fileViewModel.ThumbnailImage = thumbnail.GetBytes();
            //        }
            //    }

            //    var fileId = _fileService.SaveFile(fileViewModel);

            //    var result = UploadResult(file.FileName, file.ContentLength, file.FileName, fileId);
            //    result.thumbnailUrl = CheckThumb(file.ContentType, file.FileName, fileViewModel.ThumbnailImage);

            //    statuses.Add(result);
            //}
        }

        public ViewDataUploadFilesResult UploadResult(string fileName, int fileSize, long fileId)
        {
            string getType = MimeMapping.GetMimeMapping(fileName);
            var result = new ViewDataUploadFilesResult()
            {
                id = fileId,
                name = fileName,
                size = fileSize,
                type = getType,
                url = downloadURL + fileId,
                deleteUrl = deleteURL + fileId,
                //thumbnailUrl = CheckThumb(getType, FileName),
                deleteType = deleteType,
            };
            return result;
        }

        public string CheckThumb(string type, string FileName, byte[] thumbnail)
        {
            var splited = type.Split('/');
            if (splited.Length == 2)
            {
                string extansion = splited[1];
                if (extansion.Equals("jpeg") || extansion.Equals("jpg") || extansion.Equals("png") || extansion.Equals("gif"))
                {
                    if (thumbnail != null)
                    {
                        String thumbnailUrl = @"data:image/png;base64," + Convert.ToBase64String(thumbnail);
                        return thumbnailUrl;
                    }
                    else
                    {
                        return "~/images/upload/attach-yellow.png";
                    }
                }
                else
                {
                    if (extansion.Equals("octet-stream")) //Fix for exe files
                    {
                        return "/Content/Free-file-icons/48px/exe.png";

                    }
                    if (extansion.Contains("zip")) //Fix for exe files
                    {
                        return "/Content/Free-file-icons/48px/zip.png";
                    }
                    if (extansion.Contains("sheet") || extansion.Contains("excel")) //Fix for xls files
                    {
                        return "/Content/Free-file-icons/48px/xls.png";
                    }
                    if (extansion.Contains("document")) //Fix for doc files
                    {
                        return "/Content/Free-file-icons/48px/doc.png";
                    }
                    String thumbnailUrl = "/Content/Free-file-icons/48px/" + extansion + ".png";
                    return thumbnailUrl;
                }
            }
            else
            {
                return "";
            }

        }

        public String CheckThumbForView(String type, byte[] thumbnail)
        {
            var splited = type.Split('/');
            if (splited.Length == 2)
            {
                string extansion = splited[1];
                if (extansion.Equals("jpeg") || extansion.Equals("jpg") || extansion.Equals("png") || extansion.Equals("gif"))
                {
                    if (thumbnail != null)
                    {
                        String thumbnailUrl = @"data:image/png;base64," + Convert.ToBase64String(thumbnail);
                        return thumbnailUrl;
                    }
                    else
                    {
                        return "/images/upload/attach-yellow.png";
                    }
                }
                else
                {
                    if (extansion.Equals("octet-stream")) //Fix for exe files
                    {
                        return "/Content/Free-file-icons/512px/exe.png";

                    }
                    if (extansion.Contains("zip")) //Fix for exe files
                    {
                        return "/Content/Free-file-icons/512px/zip.png";
                    }
                    if (extansion.Contains("sheet") || extansion.Contains("excel")) //Fix for xls files
                    {
                        return "/Content/Free-file-icons/512px/xls.png";
                    }
                    if (extansion.Contains("document")) //Fix for doc files
                    {
                        return "/Content/Free-file-icons/512px/doc.png";
                    }
                    String thumbnailUrl = "/Content/Free-file-icons/512px/" + extansion + ".png";
                    return thumbnailUrl;
                }
            }
            else
            {
                return "";
            }

        }
        
        public static string SizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return "0.0 bytes"; }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            var size = string.Format("{0:n1} {1}", adjustedSize, SizeSuffixes[mag]);
            return size.GetPersianNumber();
        }
    }
    public class ViewDataUploadFilesResult
    {
        public long id { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string deleteUrl { get; set; }
        public string thumbnailUrl { get; set; }
        public string deleteType { get; set; }
    }
    public class JsonFiles
    {
        public ViewDataUploadFilesResult[] files;
        public string TempFolder { get; set; }
        public JsonFiles(List<ViewDataUploadFilesResult> filesList)
        {
            files = new ViewDataUploadFilesResult[filesList.Count];
            for (int i = 0; i < filesList.Count; i++)
            {
                files[i] = filesList.ElementAt(i);
            }

        }
    }
}