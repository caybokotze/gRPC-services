using Microsoft.AspNetCore.Mvc;

namespace HttpWebHost.Controllers
{
    [ApiController]
    [Route("")]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        [Route("/")]
        public HttpResponse Post(HttpRequest content)
        {
            var fakeName = Faker.Name.FullName();
            
            return new HttpResponse()
            {
                Message = $"Hello {fakeName} from {content.Name}"
            };
        }
    }
}