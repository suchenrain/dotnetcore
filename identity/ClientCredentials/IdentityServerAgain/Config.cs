using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServerAgain
{
    public class Config
    {
        //define api scopes
        public static IEnumerable<ApiResource> GetApiScopes()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "VendorApi",
                    DisplayName = "Vendor API",
                    Description = "Vendor API scope",
                }
            };
        }
        //define client
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId="mvc",
                    ClientName="MVC Client",

                    AllowedGrantTypes=GrantTypes.Implicit,

                    RedirectUris =
                    {
                        "http://localhost:5002/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:5002"
                    },
                    Enabled=true,
                    AccessTokenType=AccessTokenType.Jwt,
                    AllowedScopes =
                    {
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        StandardScopes.Email,
                        StandardScopes.OfflineAccess,
                        "role"
                    }
                }
            };
        }

        //define identity scopes
        public static IEnumerable<IdentityResource> GetIdentityScopes()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name="role",
                    DisplayName="User Role"
                }
            };
        }
        //define test user
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "scott",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim("name", "scott"),
                        new Claim("given_name","scott edward"),
                        new Claim("family_name", "edward"),
                        new Claim("website", "www.scottdeveloper.com"),
                        new Claim("email", "scott@mailxyz.com"),
                        new Claim("role","admin"),

                    },
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "richard",
                    Password = "password",
                    Claims = new List<Claim> {
                        new Claim("role","user")
                    }

                }
            };
        }
    }
}