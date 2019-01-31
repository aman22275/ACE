using Microsoft.AspNetCore.Antiforgery;
using DF.ACE.Controllers;

namespace DF.ACE.Web.Host.Controllers
{
    public class AntiForgeryController : ACEControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
