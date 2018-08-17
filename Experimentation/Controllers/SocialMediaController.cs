using System.Threading.Tasks;
using Experimentation.Domain;
using Experimentation.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Experimentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaApiClient _socialMediaApiClient;

        public SocialMediaController(ISocialMediaApiClient socialMediaApiClient)
        {
            _socialMediaApiClient = socialMediaApiClient;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "test api";
        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetReqResUser()
        {
            var data = await _socialMediaApiClient.GetUser("reqres");
            return Json(data.ToUser());
        }
    }
}