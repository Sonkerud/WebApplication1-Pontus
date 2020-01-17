using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityASPPontus.Services
{
    public class AccountService
    {
        private readonly IHttpContextAccessor httpContext;

        public AccountService(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext;
        }

    }
}
