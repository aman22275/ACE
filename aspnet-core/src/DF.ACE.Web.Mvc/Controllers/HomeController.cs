using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using DF.ACE.Controllers;
using DF.ACE.Web.Models.Profile;
using DF.ACE.AdditionalUserProfile;
using Abp.Runtime.Session;

namespace DF.ACE.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ACEControllerBase
    {
        public ActionResult Index()
        {
           
            return View();
        }
	}
}
