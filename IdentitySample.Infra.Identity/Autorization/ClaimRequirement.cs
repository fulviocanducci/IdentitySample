using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentitySample.CrossCutting.Identity.Authorization
{
    public class ClaimRequirement : IAuthorizationRequirement
    {
        public string ClaimName { get; set; }
        public string ClaimValue { get; set; }
        public ClaimRequirement(string claimName, string claimValue)
        {
            ClaimName = claimName;
            ClaimValue = claimValue;
        }
    }
}
