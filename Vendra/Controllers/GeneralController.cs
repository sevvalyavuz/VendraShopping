using Microsoft.AspNetCore.Mvc;
using Vendra.Data;

namespace Vendra.Controllers
{
    public class GeneralController : Controller
    {
        private readonly ApplicationDbContext db;
        public GeneralController(ApplicationDbContext db) {this.db = db;}


    }
}
