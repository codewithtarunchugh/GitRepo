using ePizzaHub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Security.Claims;

namespace ePizzaHub.UI.Controllers
{
    public class BaseController : Controller
    {
       public UserModel CurrentUser
        {
            get
            {
                if (User.Claims.Count() > 0)
                {
                    string userData = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value;
                    UserModel user = JsonSerializer.Deserialize<UserModel>(userData);
                    return user;
                }
                return null;
            }
        }
    }
}
