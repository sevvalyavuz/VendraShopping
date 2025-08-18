using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vendra.Models;

namespace Vendra.Areas.Admin.Controllers;

[Area("Admin")]
public class UserController : Controller
{
    public IActionResult UserList()
    {
            return View();       
    }
}
