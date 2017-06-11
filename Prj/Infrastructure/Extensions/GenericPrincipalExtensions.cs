using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using TSSN.FTE.Insurance.Domain.Enums;

namespace TSSN.FTE.Insurance.Web.Infrastructure.Extensions
{
    public static class GenericPrincipalExtensions
    {
        public static string DisplayName(this IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {

                var claimsIdentity = user.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    foreach (var claim in claimsIdentity.Claims)
                    {
                        if (claim.Type == "DisplayName")
                            return claim.Value;
                    }
                }
                return "";
            }
            else
                return "";
        }

        public static int SelectedUserInsuranceId(this IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {

                var claimsIdentity = user.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    foreach (var claim in claimsIdentity.Claims)
                    {
                        if (claim.Type == "UserInsuranceId")
                            return Convert.ToInt32(claim.Value);
                    }
                }
                return 0;
            }
            else
                return 0;
        }

        public static int SelectedCompanyInsuranceId(this IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {

                var claimsIdentity = user.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    foreach (var claim in claimsIdentity.Claims)
                    {
                        if (claim.Type == "CompanyInsuranceId")
                            return Convert.ToInt32(claim.Value);
                    }
                }
                return 0;
            }
            else
                return 0;
        }

        public static int SelectedCompanyId(this IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {

                var claimsIdentity = user.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    foreach (var claim in claimsIdentity.Claims)
                    {
                        if (claim.Type == "CompanyId")
                            return Convert.ToInt32(claim.Value);
                    }
                }
                return 0;
            }
            else
                return 0;
        }

        public static string SelectedCompanyName(this IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {

                var claimsIdentity = user.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    foreach (var claim in claimsIdentity.Claims)
                    {
                        if (claim.Type == "CompanyName")
                            return claim.Value;
                    }
                }
                return "";
            }
            else
                return "";
        }

        public static string SelectedAccYear(this IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                var claimsIdentity = user.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    foreach (var claim in claimsIdentity.Claims)
                    {
                        if (claim.Type == "AccYear")
                            return claim.Value;
                    }
                }
                return "";
            }
            else
                return "";
        }

        public static DateTime InsuranceBeginDate(this IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {

                var claimsIdentity = user.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    foreach (var claim in claimsIdentity.Claims)
                    {
                        if (claim.Type == "InsuranceBeginDate")
                            return Convert.ToDateTime(claim.Value);
                    }
                }
                return new DateTime();
            }
            else
                return new DateTime();
        }

        public static DateTime InsuranceEndDate(this IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {

                var claimsIdentity = user.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    foreach (var claim in claimsIdentity.Claims)
                    {
                        if (claim.Type == "InsuranceEndDate")
                            return Convert.ToDateTime(claim.Value);
                    }
                }
                return new DateTime();
            }
            else
                return new DateTime();
        }
        

        public static void AddUpdateClaim(this IPrincipal currentPrincipal, string key, string value)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return;

            // check for existing claim and remove it
            var existingClaim = identity.FindFirst(key);
            if (existingClaim != null)
                identity.RemoveClaim(existingClaim);

            // add new claim
            identity.AddClaim(new Claim(key, value));
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(new ClaimsPrincipal(identity), new AuthenticationProperties() { IsPersistent = true });
        }

        public static string GetClaimValue(this IPrincipal currentPrincipal, string key)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return null;

            var claim = identity.Claims.First(c => c.Type == key);
            return claim.Value;
        }

        
        public static bool IsBroker(this IPrincipal user)
        {
            return user.IsInRole(StandardRoleEnum.Broker.ToString());
        }

        public static bool IsAdmin(this IPrincipal user)
        {
            return user.IsInRole(StandardRoleEnum.Admin.ToString());
        }

        public static bool IsCompany(this IPrincipal user)
        {
            return user.IsInRole(StandardRoleEnum.Company.ToString());
        }

        public static bool IsUser(this IPrincipal user)
        {
            return user.IsInRole(StandardRoleEnum.User.ToString());
        }

        public static bool IsEvaluatorExpert(this IPrincipal user)
        {
            return user.IsInRole(StandardRoleEnum.EvaluatorExpert.ToString());
        }

        public static bool IsFinancial(this IPrincipal user)
        {
            return user.IsInRole(StandardRoleEnum.Financial.ToString());
        }

    }
}