using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.AppRole;

namespace WebApp.Extensions
{
    public static class IConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddVault(this IConfigurationBuilder builder)
        {
            try
            {
                var buildConfig = builder.Build();
                var vaultConfig = buildConfig.GetSection("vault").Get<VaultConfig>();

                IAuthMethodInfo authMethod = new AppRoleAuthMethodInfo(vaultConfig.RoleId, vaultConfig.SecretId);
                VaultClientSettings authSettings = new VaultClientSettings(vaultConfig.VaultLocation, authMethod);

                IVaultClient vaultClient = new VaultClient(authSettings);

                var vaultSecrets = vaultClient.V1.Secrets.KeyValue.V2
                    .ReadSecretAsync("secrets/kv/foo")
                    .Result
                    .Data
                    .Data
                    .Select(x => new KeyValuePair<string, string>($"vault:{x.Key}", x.Value.ToString()));

                return builder.AddInMemoryCollection(vaultSecrets);
            }
            catch (Exception ex)
            {
                throw new Exception($"Vault configuration failed: {ex.Message}");
            }
        }
    }
}