using Microsoft.AspNetCore.Mvc;
using xduMVPApp.Models;

namespace xduMVPApp.Controllers;

public class UsersController : Controller {
    private UsersContext uc = new();
    // GET
    public IActionResult xduView() {
        return View(uc.XduTables.ToList());
    }
}