using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CRUDAPI.Controllers;
namespace CRUDAPI.Helpers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        // private readonly IOptions<AppSettings> _appSettings;
        //public BasicAuthenticationHandler(
        //   IOptions<AppSettings> appSettings, 
        //   IOptionsMonitor<AuthenticationSchemeOptions> options,
        //   ILoggerFactory logger, UrlEncoder encoder, 
        //   ISystemClock clock)
        //   : base(options, logger, encoder, clock)
        //{
        //    _appSettings = appSettings;
        //}

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {

        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (string.IsNullOrEmpty(Request.Headers.Authorization))
            {
                return AuthenticateResult.Fail("Authorization header is missing");
            }

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers.Authorization!);
                if (string.IsNullOrEmpty(authHeader.Parameter))
                {
                    return AuthenticateResult.Fail("Authorization header parameter is missing");
                }
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                var username = credentials.FirstOrDefault();
                var password = credentials.LastOrDefault();

                if (IsValidUser(username?.ToString() ?? string.Empty, password?.ToString() ?? string.Empty))
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, username ?? string.Empty) };

                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
                else
                {
                    return AuthenticateResult.Fail($"Authentication failed, Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail($"Authentication failed: {ex.Message}");
            }
        }

        private bool IsValidUser(string username, string password)
        {
            bool val1;
            CRUDAPI.Helpers.ValidateClass1 obj2= new ValidateClass1();
            val1 = Convert.ToBoolean(obj2.chkusercnt(Convert.ToString(username), Convert.ToString(password)));
            return val1;
            
        }


    }


}
