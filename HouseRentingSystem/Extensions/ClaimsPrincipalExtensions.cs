﻿using System.Security.Claims;

namespace HouseRentingSystem.Extensions
{
    public static class ClaimsPrincipalExtensions // Identity
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
