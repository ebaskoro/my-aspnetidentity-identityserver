using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;


namespace IdentityServer
{

    /// <summary>
    /// Configuration.
    /// </summary>
    public class Config
    {

        /// <summary>
        /// Gets the collection of API resources available.
        /// </summary>
        /// <returns>Collection of available API resources.</returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api", "Hero API")
            };
        }


        /// <summary>
        /// Gets the collection of clients.
        /// </summary>
        /// <returns>Collection of clients.</returns>
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "console",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("password".Sha256())
                    },
                    AllowedScopes =
                    {
                        "api"
                    }
                },
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("password".Sha256())
                    },
                    AllowedScopes =
                    {
                        "api"
                    }
                },
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "ASP.NET Core MVC Application",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("password".Sha256())
                    },
                    RedirectUris =
                    {
                        "http://localhost:5000/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:5000/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api"
                    },
                    AllowOfflineAccess = true
                },
                new Client
                {
                    ClientId = "js",
                    ClientName = "Angular Application",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris =
                    {
                        "http://localhost:4200",
                        "http://localhost:5000"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:4200",
                        "http://localhost:5000"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://localhost:4200",
                        "http://localhost:5000"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api"
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
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password",
                    Claims = new[]
                    {
                        new Claim("name", "Alice"),
                        new Claim("email", "alice@example.com")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password",
                    Claims = new[]
                    {
                        new Claim("name", "Bob"),
                        new Claim("email", "bob@example.com")
                    }
                }
            };
        }


        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

    }

}
