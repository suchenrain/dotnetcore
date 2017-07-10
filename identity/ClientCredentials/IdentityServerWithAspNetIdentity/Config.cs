﻿using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerWithAspNetIdentity
{
    public class Config
    {
        //scopes=>define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1","My API")
            };
        }

        //clients => want to access resources(aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            //OpenID Connect hybrid flow and client credentials
            return new List<Client>
            {
                new Client
                {
                    ClientId="hybrid",
                    ClientName="MVC Client",
                    AllowedGrantTypes=GrantTypes.HybridAndClientCredentials,

                    RequireConsent=true,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris={"http://localhost:5002/signin-oidc"},
                    PostLogoutRedirectUris={ "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes={"api1",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                    },

                    AllowOfflineAccess=true
                }
            };
        }
    }
}