using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HttpWebHost.Controllers
{
    [ApiController]
    [Route("")]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        [Route("/")]
        public string Post(MessagePayload content)
        {
            var fakeName = Faker.Name.FullName();
            return $"Hello {fakeName} from {content.Name}";
        }
    }
}