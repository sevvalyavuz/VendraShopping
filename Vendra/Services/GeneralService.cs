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


    }
}
