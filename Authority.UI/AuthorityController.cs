using Common.ExpandMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authority.UI
{
    public class AuthorityOauthController: OauthController
    {
        protected override string GetTokenUrl()
        {
            return "http://192.168.200.123/hanatechalarm/token";
        }
    }
}