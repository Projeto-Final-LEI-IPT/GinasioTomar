using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppGCT.Pages.Gestao.Utilizadores
{

    [Authorize(Roles = "Administrador")]
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public IndexModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }



    }
}