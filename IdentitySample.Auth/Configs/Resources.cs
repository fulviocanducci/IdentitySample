using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentitySample.Auth.Configs
{
    public static class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "Api")
            };
        }
    }
}
