using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CreateWebForm.Data;
using CreateWebForm.Model;

namespace CreateWebForm.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CreateWebFormContext _context;

        public IndexModel(CreateWebFormContext context)
        {
            _context = context;
        }

        public IList<CreateWebFormTable> CreateWebFormTable { get; set; }

        /// <summary>
        /// Get records
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            CreateWebFormTable = await _context.FormTable.ToListAsync();
        }



        [BindProperty]
        public CreateWebFormTable CreateWebForm { get; set; }

        /// <summary>
        /// Save records
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            CreateWebForm.Date= CreateWebForm.Date.AddDays(CreateWebForm.Number);
            _context.FormTable.Add(CreateWebForm);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        /// <summary>
        /// Delete Records
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CreateWebForm = await _context.FormTable.FindAsync(id);

            if (CreateWebForm != null)
            {
                _context.FormTable.Remove(CreateWebForm);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

    }
}
