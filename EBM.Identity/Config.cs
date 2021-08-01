// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace EBM.Identity
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
         new List<ApiScope>
         {
            new ApiScope("Iterations", "Iterations API")
         };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                    new Client
                    {
                        ClientId = "client",

                        // no interactive user, use the clientid/secret for authentication
                        AllowedGrantTypes = GrantTypes.ClientCredentials,

                        // secret for authentication
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },

                        // scopes that client has access to
                        AllowedScopes = { "Iterations" }
                    }
            };
    }
}