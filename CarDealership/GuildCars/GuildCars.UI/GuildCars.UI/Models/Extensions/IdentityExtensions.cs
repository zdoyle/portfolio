using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.UI;

namespace GuildCars.UI.Models.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetEmployeeId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("EmployeeId");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static bool GetIsDisabled(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("IsDisabled");
            // Test for null to avoid issues during local testing
            return (claim != null) ? Boolean.Parse(claim.Value) : false;
        }

        public static string GetEmail(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Email");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}