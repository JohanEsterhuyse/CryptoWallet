using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace CryptoWallet.Identity
{
    public class Config
    {
        //Defining the API that will have access to the IdentityServer
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API"),
                new ApiResource("tswTools", "Tools API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client1",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                // scopes that client has access to
                    AllowedScopes = { "api1", "tswTools" }
                },
                new Client
                {
                    ClientId = "client2",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret ("SomeSecret".Sha256())
                    },
                    AllowedScopes = { "api1","tswTools" }
                }
            };
        }

        //Todo: Replaced with an actual implementation
        public static List<TestUser> GetUser()
        {
            return new List<TestUser>
            {
            new TestUser
                {
                    SubjectId = "1",
                    Username = "Johan",
                    Password = "password"
                },
            new TestUser
                {
                    SubjectId = "2",
                    Username = "Test",
                    Password="password"
                }
            };
        }
    }
}
