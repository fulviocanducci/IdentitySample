using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentitySample.Auth.Configs
{
    public static class Users
    {
        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "user1",
                    Password = "password1",

                }
            };
        }
    }
}
