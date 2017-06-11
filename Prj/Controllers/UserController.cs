using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TSSN.FTE.Insurance.DTO;
using TSSN.FTE.Insurance.DTO.Users;
using TSSN.FTE.Insurance.Service.Contracts;
using TSSN.FTE.Insurance.Web.Common.CustomModelBinders;
using TSSN.FTE.Insurance.Web.CustomModelBinders;
using TSSN.Utility;

namespace TSSN.FTE.Insurance.Web.Controllers
{
    public partial class UserController : Controller
    {
        private readonly ITransService _transService;
        private readonly ICompanyInsuranceService _companyInsuranceService;
        private readonly ITariffCategoryService _tariffCategoryService;
        private readonly IUserInsuranceService _userInsuranceService;
        
        public UserController(ITransService transService, ICompanyInsuranceService companyInsuranceService,
            ITariffCategoryService tariffCategoryService, IUserInsuranceService userInsuranceService)
        {
            // TODO: It will remove after using an IoC Container

            _transService = transService;
            _companyInsuranceService = companyInsuranceService;
            _tariffCategoryService = tariffCategoryService;
            _userInsuranceService = userInsuranceService;
            //_generalService = new GeneralService(_unitOfWork);            
            //_fileService = new FileService(_unitOfWork);

        }
        

    }
}