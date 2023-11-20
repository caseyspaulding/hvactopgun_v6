﻿using HVACTopGun.DataAccess.Features.Tenants;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace HVACTopGun.Services.Auth
{
    public static class AuthenticationStateProviderHelpers
    {
        public static async Task<int?> GetTenantIdFromAuth(
            this AuthenticationStateProvider provider,
            ITenantRepository tenantDataService)
        {
            var authState = await provider.GetAuthenticationStateAsync();
            var objectId = authState.User.FindFirstValue("http://schemas.microsoft.com/identity/claims/objectidentifier");

            if (string.IsNullOrEmpty(objectId))
            {
                throw new InvalidOperationException("Unable to find ObjectIdentifier claim.");
            }

            var tenantId = await tenantDataService.GetTenantIdByObjectId(objectId);

            if (tenantId == null)
            {
                throw new InvalidOperationException($"Unable to find tenant for ObjectIdentifier: {objectId}");
            }

            return tenantId; // Return the int directly
        }
    }
}
