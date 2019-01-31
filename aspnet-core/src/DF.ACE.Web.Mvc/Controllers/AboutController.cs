using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using DF.ACE.Controllers;

namespace DF.ACE.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : ACEControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
