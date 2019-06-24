using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CondominiumNetwork.DomainModel.Identity
{
    public static class ExtensionMethods
    {
        public static string getUserId(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return null;

            ClaimsPrincipal currentUser = user;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
