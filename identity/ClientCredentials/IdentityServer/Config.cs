using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

public class Config
{
    //scopes define the Api resources in your system
    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>
        {
            new ApiResource("api1","My Api")
        };
    }

    //client want to access resources
    public static IEnumerable<Client> GetClients()
    {
        return new List<Client>
                {
                    new Client
                    {
                        ClientId="client",
                        AllowedGrantTypes=GrantTypes.ClientCredentials,
                        ClientSecrets=
                        {
                            new Secret("secret".Sha256())
                        },
                        AllowedScopes={"api1"}
                    },
                    //owner pwd
                    new Client
                    {
                        ClientId="ro.client",
                        AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                        ClientSecrets=
                        {
                            new Secret("secret".Sha256())
                        },
                        AllowedScopes={"api1"}
                    },
                    // OpenID Connect implicit flow client (MVC)
                    new Client
                    {
                        ClientId = "mvc",
                        ClientName = "MVC Client",
                        AllowedGrantTypes = GrantTypes.Implicit,

                        // where to redirect to after login
                        RedirectUris = { "http://localhost:5002/signin-oidc" },

                        // where to redirect to after logout
                        PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                        AllowedScopes = new List<string>
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile
                        }
                    },
                    // OpenID Connect hybrid flow and client credentials client(MVC)
                    new Client
                    {
                        ClientId="hybrid",
                        ClientName="Hybrid Client",
                        AllowedGrantTypes=GrantTypes.HybridAndClientCredentials,

                        ClientSecrets=
                        {
                            new Secret("secret".Sha256())
                        },

                        // where to redirect to after login
                        RedirectUris = { "http://localhost:5002/signin-oidc" },

                        // where to redirect to after logout
                        PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                        AllowedScopes =
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "api1"
                        },
                        AllowOfflineAccess=true
                    },
                    // JavaScript Client
                    new Client
                    {
                        ClientId = "js",
                        ClientName = "JavaScript Client",
                        AllowedGrantTypes = GrantTypes.Implicit,
                        AllowAccessTokensViaBrowser = true,

                        RedirectUris =           { "http://localhost:5003/callback.html" },
                        PostLogoutRedirectUris = { "http://localhost:5003/index.html" },
                        AllowedCorsOrigins =     { "http://localhost:5003" },

                        AllowedScopes =
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "api1"
                        }
                    }
                };
    }

    public static List<TestUser> GetUsers()
    {
        return new List<TestUser>
        {
            new TestUser
            {
                SubjectId="1",
                Username="alice",
                Password="password"
            },
            new TestUser
            {
                SubjectId="2",
                Username="bob",
                Password="password"
            }
        };
    }

    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
    }
}