using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeopleApi.Models;
using PeopleApi.Services;

namespace PeopleApi.Areas.Razor.Pages
{
    public class CreatePersonModel : PageModel
    {
        private readonly PeopleService _service;

        [BindProperty]
        public People Person { get; set; }
        public CreatePersonModel(PeopleService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _service.Create(Person);
            return RedirectToPage("./ListPeople");
        }


    }
}
