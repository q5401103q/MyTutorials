using BimCheck.Common;
using BimCheck.Dal;
using BimCheck.IBll;
using BimCheck.IDal;
using BimCheck.Model.Dto;
using BimCheck.Model.Entity;
using BimCheck.Model.Search;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace BimCheck.Api.Core
{
    public class SimpleAuthorizationProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Factory.StartNew(() => context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            await Task.Factory.StartNew(() => context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" }));

            /*
             * 对用户名、密码进行数据校验
             */

            var password = MD5Helper.ComputeMD5(context.Password);
            string sql = "SELECT * FROM T_USER WHERE USERNAME = @P_USERNAME AND PASSWORD= @P_PASSWORD";

            var repo = new RepositoryBase(new SessionBase());
            var user = repo.GetFirstOrDefault<T_User>(sql, new { P_USERNAME = context.UserName, P_PASSWORD = password });
            if (user == null)
            {
                context.SetError("invalid_grant", "用户名或密码无效");
                return;
            }


            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

            context.Validated(identity);
        }
    }
}