using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
       
    }
}
