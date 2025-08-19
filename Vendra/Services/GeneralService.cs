using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vendra.Data;

namespace Vendra.Services
{
    public class GeneralService : Controller
    {
        private readonly ApplicationDbContext db;
        public GeneralService(ApplicationDbContext db){this.db = db;}

        public IEnumerable<SelectListItem> GetUserTypeList(string type = "", bool code = false)
             => db.UserTypes.Where(x => x.Grup == type || type == "")
                            .Select(i => new SelectListItem() { Value = code ? i.Id.ToString() : i.Name, Text = i.Name })
                            .ToList();

        public JsonResult GetUserTypeListJson(string type = "") => Json(GetUserTypeList(""));

    }
}
