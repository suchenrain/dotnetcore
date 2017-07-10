using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[] {
                new ApiResource("api1", "My Api"),

                    new ApiResource {
                        Name = "api2",
                            DisplayName = "My Api2",
                            ApiSecrets = {
                                new Secret("secret".Sha256())
                            },
                            Scopes = {
                                new Scope() {
                                    Name = "api2.full_access",
                                        DisplayName = "Full access to Api 2"
                                },
                                new Scope {
                                    Name = "api2.read_only",
                                        DisplayName = "Read only access to Api2"
                                }

                            }

                    }
            };
        }
        public static IEnumerable<Client> GetClientResoureces()
        {
            return new List<Client> {

                //server to server
                new Client {
                    ClientId = "service.client",
                        ClientSecrets = {
                            new Secret("secret".Sha256())
                        },

                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        AllowedScopes = {
                            "api1",
                            "api2.read_only"
                        }
                },
                //browser based javascript client
                new Client {
                    ClientId = "js",
                        ClientName = "Javascript Client",
                        ClientUri = "http://localhost:5003",

                        AllowedGrantTypes = GrantTypes.Implicit,
                        AllowAccessTokensViaBrowser = true,

                        RedirectUris = {
                            "http://localhost:5003/callback.html"
                        },
                        PostLogoutRedirectUris = {
                            "http://localhost:5003/index.html"
                        },
                        AllowedCorsOrigins = {
                            "http://localhost:5003"
                        },

                        AllowedScopes = {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            IdentityServerConstants.StandardScopes.Email,
                            "api1",
                            "api2.read_only"
                        }
                },
                // server-side web application
                new Client {
                    ClientId = "mvc",
                        ClientName = "MVC Client",
                        ClientUri = "http://localhost:5002",

                        AllowedGrantTypes = GrantTypes.Hybrid,
                        AllowOfflineAccess = true,
                        ClientSecrets = {
                            new Secret("secret".Sha256())
                        },

                        RedirectUris = {
                            "http://localhost:5002/signin-oidc"
                        },
                        PostLogoutRedirectUris = {
                            "http://localhost:5002/signout-callback-oidc"
                        },
                        LogoutUri = "http://localhost:5002/signout-oidc",

                        AllowedScopes = {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            IdentityServerConstants.StandardScopes.Email,

                            "api1",
                            "api2.read_only"
                        },

                }
            };
        }
    }
}