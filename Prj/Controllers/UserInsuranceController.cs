using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TSSN.FTE.Insurance.DTO;
using TSSN.FTE.Insurance.Service.Contracts;
using TSSN.FTE.Insurance.Web.Common.CustomModelBinders;
using TSSN.FTE.Insurance.Web.CustomModelBinders;
using TSSN.FTE.Insurance.Web.Common.Filters;
using System;
using TSSN.FTE.Insurance.Web.Common.Exceptions;
using TSSN.FTE.Insurance.Web.Infrastructure.Extensions;

namespace TSSN.FTE.Insurance.Web.Controllers
{
    [HIErrorHandler]
    //[Authorize]
    public partial class UserInsuranceController : Controller
    {
        private readonly ITransService _transService;
        private readonly ICompanyInsuranceService _companyInsuranceService;
        private readonly ITariffCategoryService _tariffCategoryService;
        private readonly IUserInsuranceService _userInsuranceService;
        //private readonly IGeneralService _generalService;
        //private readonly IFileService _fileService;

        public UserInsuranceController(ITransService transService, ICompanyInsuranceService companyInsuranceService,
            ITariffCategoryService tariffCategoryService, IUserInsuranceService userInsuranceService)
        {
            // TODO: It will remove after using an IoC Container

            _transService = transService;
            _companyInsuranceService = companyInsuranceService;
            _tariffCategoryService = tariffCategoryService;
            _userInsuranceService = userInsuranceService;

        }

        public virtual async Task<ActionResult> List()
        {
            SearchUserInsuranceDto model = new SearchUserInsuranceDto();
            var companies = await _companyInsuranceService.GetCompanyInsuranceList(new SearchCompanyInsuranceDto());
            model.Companies = companies.Items;
            model.CompanyInsuranceId = User.SelectedCompanyInsuranceId();
            return View(model);
        }

        public virtual async Task<JsonResult> GetCompanyUsers(JQueryDataTablesModel jQueryDataTablesModel, SearchUserInsuranceDto searchModel)
        {
            jQueryDataTablesModel.MapPagingToModel(searchModel);
            searchModel.UserInsuranceId = User.SelectedUserInsuranceId();
            var models = await _userInsuranceService.GetUserInsuranceList(searchModel);
            return Json(new JQueryDataTablesResponse<UserInsuranceListDto>(items: models.Items,
                totalRecords: models.TotalCount,
                totalDisplayRecords: models.TotalCount,
                sEcho: jQueryDataTablesModel.sEcho));
        }

        [HttpPost]
        [AllowUploadSpecialFilesOnly(".xls,.xlsx", justImage: false)]
        public virtual async Task<JsonResult> UploadExcel(ImportFromExcelInputDto model)
        {
            await _userInsuranceService.ImportExcelUserInsuranceListToDB(model);

            return new JsonResult
            {
                Data = new
                {
                    success = true
                }
            };
        }
    }
}