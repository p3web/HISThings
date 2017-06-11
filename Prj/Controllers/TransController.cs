using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TSSN.FTE.Insurance.Web.Infrastructure.Extensions;
using System.Web.Mvc;
using TSSN.FTE.Insurance.DTO;
using TSSN.FTE.Insurance.Service.Contracts;
using TSSN.FTE.Insurance.Web.Common.CustomModelBinders;
using TSSN.FTE.Insurance.Web.CustomModelBinders;
using TSSN.Utility;
using TSSN.FTE.Insurance.Web.Common;
using TSSN.FTE.Insurance.Web.Common.Filters;
using TSSN.FTE.Insurance.Domain.Enums;
using TSSN.FTE.Insurance.Web.Common.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace TSSN.FTE.Insurance.Web.Controllers
{
    [HIErrorHandler]
    //[Authorize]
    public partial class TransController : Controller
    {
        private readonly ITransService _transService;
        private readonly ICompanyInsuranceService _companyInsuranceService;
        private readonly ITariffCategoryService _tariffCategoryService;
        private readonly IUserInsuranceService _userInsuranceService;
        private readonly IDocumentService _documentService;

        public TransController(ITransService transService, ICompanyInsuranceService companyInsuranceService,
            ITariffCategoryService tariffCategoryService, IUserInsuranceService userInsuranceService,/*, IFileService fileService*/
            IDocumentService documentService)
        {
            _transService = transService;
            _companyInsuranceService = companyInsuranceService;
            _tariffCategoryService = tariffCategoryService;
            _userInsuranceService = userInsuranceService;
            _documentService = documentService;
            //_fileService = fileService;
        }


        public virtual async Task<ActionResult> List()
        {
            SearchTransDto model = new SearchTransDto();
            var companies = await _companyInsuranceService.GetCompanyInsuranceList(new SearchCompanyInsuranceDto());
            model.Companies = companies.Items;
            model.CompanyInsuranceId = User.SelectedCompanyInsuranceId();
            model.TariffCategories = await _tariffCategoryService.GetTariffCategoryList(new SearchTariffCategoryDto { CompanyInsuranceId = model.CompanyInsuranceId });

            return View(model);
        }

        //public virtual async Task<JsonResult> GetCreatedTransList(JQueryDataTablesModel jQueryDataTablesModel, SearchTransDto searchModel)
        //{
        //    searchModel.UserTransStatus = UserTransStatusEnum.CreateTrans;
        //    var transList = await getTransList(jQueryDataTablesModel, searchModel);
        //    return Json(transList);
        //}

        [HttpPost]
        public virtual async Task<JsonResult> GetCreatedTransList(SearchTransDto searchModel)
        {
            searchModel.UserTransStatus = UserTransStatusEnum.CreateTrans;
            var transList = await getTransList_new(searchModel);            
            return Json(transList, JsonRequestBehavior.AllowGet);
        }

        public virtual async Task<JsonResult> GetCompanyUsers(SearchUserInsuranceDto model)
        {
            model.UserInsuranceId = User.SelectedUserInsuranceId();
            var users = await _userInsuranceService.GetUserInsuranceList(model);

            var selectUsers = users.Items.Select(x => new { value = x.PatientName, data = x }).ToList();
            return Json(selectUsers, JsonRequestBehavior.AllowGet);
        }

        public virtual async Task<PartialViewResult> _Create(int compnayInsuranceId)
        {
            var model = new CreateTransDto();
            model.TransDate = DateTime.Now;
            model.PageCount = 1;
            model.TariffCategoryList = await _tariffCategoryService.GetTariffCategoryList(new SearchTariffCategoryDto { CompanyInsuranceId = compnayInsuranceId });
            model.CompanyInsuranceId = compnayInsuranceId;
            return PartialView(model);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create(CreateTransDto model)
        {
            //if (model.TransDate == DateTime.Now.Date)
            //{
            //    ModelState.AddModelError("", "مهلت ثبت هزینه حداکثر 3 ماه می باشد.");
            //}

            if (!ModelState.IsValid)
            {
                model.TariffCategoryList = await _tariffCategoryService.GetTariffCategoryList(new SearchTariffCategoryDto { CompanyInsuranceId = model.CompanyInsuranceId });

                if (Request.IsAjaxRequest())
                    return PartialView(MVC.Trans.Views._Create, model);
                return View(MVC.Trans.Views._Create, model);
            }
            await _transService.Create(model);

            // todo: 
            return new JsonResult
            {
                Data = new
                {
                    success = true
                }
            };
        }

        public virtual async Task<ActionResult> _Edit(int companyInsuranceId, int transId)
        {
            var model = await _transService.GetForEdit(transId);
            model.TariffCategoryList = await _tariffCategoryService.GetTariffCategoryList(new SearchTariffCategoryDto());
            model.CompanyInsuranceId = companyInsuranceId;
            return PartialView(MVC.Trans.Views._Edit, model);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Edit(EditTransDto model)
        {
            await _transService.Edit(model);

            return new JsonResult
            {
                Data = new
                {
                    success = true
                }
            };
        }

        [HttpPost]
        public virtual async Task<ActionResult> Delete(int transId)
        {

            return new JsonResult
            {
                Data = new
                {
                    success = true
                }
            };
        }

        public virtual async Task<PartialViewResult> _EditTransDocument(int transId)
        {
            SessionBag.Current.DocumentIdList = null;
            var model = await _transService.GetForEdit(transId);
            return PartialView(MVC.Trans.Views._EditTransDocument, model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual async Task<ActionResult> EditTransDocument(EditTransDto model)
        {
            var transId = model.TransId;

            List<long> documentIds = SessionBag.Current.DocumentIdList ?? new List<long>();
            SessionBag.Current.DocumentIdList = null;

            if (!documentIds.Any())
            {
                return new JsonResult
                {
                    Data = new
                    {
                        notChanged = true
                    }
                };
            }

            //_fileService.DeleteFilesByUserInsurance(userInsuranceId, documentIds.First());

            //_unitOfWork.Configuration.ValidateOnSaveEnabled = false;
            //_userInsuranceService.UpdateUserInsuranceDocument(userInsuranceId, documentIds.First());
            //await _unitOfWork.SaveChangesAsync();
            //_unitOfWork.Configuration.ValidateOnSaveEnabled = true;

            await _documentService.UpdateDocumentTransId(documentIds.First(), model.TransId);

            return new JsonResult
            {
                Data = new
                {
                    success = true
                }
            };
        }


        //public virtual async Task<ActionResult> EditTransDocument(SearchUserInsuranceDto model)
        //{
        //try
        //{
        //    var userInsuranceId = model.Id;

        //    List<int> FileIds = SessionBag.Current.FileIdList ?? new List<int>();
        //    SessionBag.Current.FileIdList = null;

        //    if (!FileIds.Any())
        //    {
        //        //return RedirectToAction(MVC.User.ActionNames.AssuredInfo).WithNotification("خطای اطلاعات ناقص، لطفا مجددا تلاش نمایید", alertType: AlertType.error, position: Position.topCenter, timeOut: 3000);


        //        return RedirectToAction(MVC.UserInsurance.ActionNames.List)
        //        .Notification.notify("error", "top left", "شما هیچ اطلاعات تغییر داده شده ای ندارید");
        //       //.WithNotification("شما هیچ اطلاعات تغییر داده شده ای ندارید", alertType: AlertType.warning, position: Position.topCenter, timeOut: 3000);
        //    }

        //    _fileService.DeleteFilesByUserInsurance(userInsuranceId, FileIds.First());

        //    _unitOfWork.Configuration.ValidateOnSaveEnabled = false;
        //    _userInsuranceService.UpdateUserInsuranceDocument(userInsuranceId, FileIds.First());
        //    await _unitOfWork.SaveChangesAsync();
        //    _unitOfWork.Configuration.ValidateOnSaveEnabled = true;

        //    return RedirectToAction(MVC.UserInsurance.ActionNames.List)
        //    .Notification.notify("success", "top left", "اطلاعات با موفقیت ذخیره شد");
        //    //.WithNotification("اطلاعات با موفقیت ذخیره شد", alertType: AlertType.success, position: Position.topCenter, timeOut: 3000);
        //}
        //catch (Exception ex)
        //{
        //    Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
        //    return RedirectToAction(MVC.UserInsurance.ActionNames.List).WithNotification("خطای ناشناخته رخ داده است، لطفا مجددا تلاش نمایید", alertType: AlertType.error, position: Position.topCenter, timeOut: 3000);
        //}
        //}

        public virtual async Task<ActionResult> SendTrans()
        {
            SearchTransDto model = new SearchTransDto();
            var companies = await _companyInsuranceService.GetCompanyInsuranceList(new SearchCompanyInsuranceDto());
            model.Companies = companies.Items;
            model.CompanyInsuranceId = User.SelectedCompanyInsuranceId();
            model.TariffCategories = await _tariffCategoryService.GetTariffCategoryList(new SearchTariffCategoryDto { CompanyInsuranceId = model.CompanyInsuranceId });

            return View(model);
        }
        [HttpPost]
        public virtual async Task<ActionResult> SendTransToInsurance(SendTransToInsuranceDto model)
        {
            try
            {
                var trackingNumber = await _transService.SendTransToInsurance(model);

                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        trackingNo = trackingNumber
                    }
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public virtual async Task<ActionResult> BackedTrans()
        {
            SearchTransDto model = new SearchTransDto();
            var companies = await _companyInsuranceService.GetCompanyInsuranceList(new SearchCompanyInsuranceDto());
            model.Companies = companies.Items;
            model.TariffCategories = await _tariffCategoryService.GetTariffCategoryList(new SearchTariffCategoryDto { CompanyInsuranceId = model.CompanyInsuranceId });

            return View(model);
        }

        public virtual async Task<JsonResult> GetBackedTransList(JQueryDataTablesModel jQueryDataTablesModel, SearchTransDto searchModel)
        {
            searchModel.UserTransStatus = UserTransStatusEnum.BackToUser;
            var transList = await getTransList(jQueryDataTablesModel, searchModel);
            return Json(transList);
        }

        // دریافت هزینه
        [Authorize(Roles = "Admin,Broker")]
        public virtual async Task<ActionResult> GetTrans()
        {
            SearchTransDto model = new SearchTransDto();
            var companies = await _companyInsuranceService.GetCompanyInsuranceList(new SearchCompanyInsuranceDto());
            model.Companies = companies.Items;
            model.TariffCategories = await _tariffCategoryService.GetTariffCategoryList(new SearchTariffCategoryDto { CompanyInsuranceId = model.CompanyInsuranceId });

            return View(model);
        }

        [Authorize(Roles = "Admin,Broker")]
        public virtual async Task<JsonResult> GetTransListForReceive(JQueryDataTablesModel jQueryDataTablesModel, SearchTransDto searchModel)
        {
            searchModel.TransStatus = TransStatusEnum.SendToInsuranceAgent;
            var transList = await getTransList(jQueryDataTablesModel, searchModel);
            return Json(transList);
        }

        // ارزیابی خسارت
        [Authorize(Roles = "Admin,Broker")]
        public virtual async Task<ActionResult> TransBrokerEvaluation()
        {
            SearchTransDto model = new SearchTransDto();
            var companies = await _companyInsuranceService.GetCompanyInsuranceList(new SearchCompanyInsuranceDto());
            model.Companies = companies.Items;
            model.TariffCategories = await _tariffCategoryService.GetTariffCategoryList(new SearchTariffCategoryDto { CompanyInsuranceId = model.CompanyInsuranceId });

            return View(model);
        }


        [Authorize(Roles = "Admin,Broker,")]
        public virtual async Task<JsonResult> GetTransListForBrokerEvaluation(JQueryDataTablesModel jQueryDataTablesModel, SearchTransDto searchModel)
        {
            searchModel.TransStatus = TransStatusEnum.GetTrans;
            var transList = await getTransList(jQueryDataTablesModel, searchModel);
            return Json(transList);
        }

        // ارزیابی خسارت
        [Authorize(Roles = "Admin,EvaluatorExpert")]
        public virtual async Task<ActionResult> TransExpertEvaluation()
        {
            SearchTransDto model = new SearchTransDto();
            var companies = await _companyInsuranceService.GetCompanyInsuranceList(new SearchCompanyInsuranceDto());
            model.Companies = companies.Items;
            model.TariffCategories = await _tariffCategoryService.GetTariffCategoryList(new SearchTariffCategoryDto { CompanyInsuranceId = model.CompanyInsuranceId });

            return View(model);
        }

        [Authorize(Roles = "Admin,EvaluatorExpert")]
        public virtual async Task<JsonResult> GetTransListForExpertEvaluation(JQueryDataTablesModel jQueryDataTablesModel, SearchTransDto searchModel)
        {
            searchModel.TransStatus = TransStatusEnum.SendToTransEvaluator;
            var transList = await getTransList(jQueryDataTablesModel, searchModel);
            return Json(transList);
        }


        public virtual async Task<JsonResult> GetCompanyTariffCategoryList(SearchTariffCategoryDto model)
        {
            var hazinehList = await _tariffCategoryService.GetTariffCategoryList(model);
            return Json(hazinehList, JsonRequestBehavior.AllowGet);
        }


        #region Private Methods
        private async Task<JQueryDataTablesResponse<TransListDto>> getTransList(JQueryDataTablesModel jQueryDataTablesModel, SearchTransDto searchModel)
        {
            jQueryDataTablesModel.MapPagingToModel(searchModel);
            searchModel.UserInsuranceId = User.SelectedUserInsuranceId();
            var models = await _transService.GetTransList(searchModel);

            return new JQueryDataTablesResponse<TransListDto>(items: models.Items,
                totalRecords: models.TotalCount,
                totalDisplayRecords: models.TotalCount,
                sEcho: jQueryDataTablesModel.sEcho);
        }


        private async Task<PagedResultOutput<TransListDto>> getTransList_new(SearchTransDto searchModel)
        {
            searchModel.UserInsuranceId = User.SelectedUserInsuranceId();
            var models = await _transService.GetTransList(searchModel);

            return models;
        }
        #endregion
    }
}