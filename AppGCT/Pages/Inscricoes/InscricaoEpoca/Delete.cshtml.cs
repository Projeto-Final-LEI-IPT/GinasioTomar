﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;
using Microsoft.AspNetCore.Authorization;

namespace AppGCT.Pages.Inscricoes.InscricaoEpoca
{
    [Authorize(Roles = "Administrador")]
    public class DeleteModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public DeleteModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Inscricao Inscricao { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inscricao == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricao.Include(i => i.Atleta).Include(i => i.Periodo).Include(i => i.Class).Include(i => i.Descont)
                                                    .FirstOrDefaultAsync(m => m.Id == id);

            if (inscricao == null)
            {
                return NotFound();
            }
            else 
            {
                Inscricao = inscricao;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Inscricao == null)
            {
                return NotFound();
            }
            var inscricao = await _context.Inscricao.FindAsync(id);

            if (inscricao != null)
            {
                Inscricao = inscricao;
                // Obtem planoMensalidade associados
                var planoMensalidades = await _context.PlanoMensalidade
                    .Where(p => p.GinastaId == Inscricao.GinastaId && p.EpocaId == Inscricao.EpocaId)
                    .ToListAsync();
                //remove planoMensalidades
                _context.PlanoMensalidade.RemoveRange(planoMensalidades);
                //remove inscrição
                _context.Inscricao.Remove(Inscricao);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { id = Inscricao.GinastaId });
        }
    }
}
