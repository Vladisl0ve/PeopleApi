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
    public class ListPeopleModel : PageModel
    {
        private readonly PeopleService _service;

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Surname { get; set; }
        [BindProperty]
        public int Age { get; set; }

        public IList<People> PeopleList { get; set; }
        public ListPeopleModel(PeopleService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            PeopleList = _service.Get().ToList();
        }
    }
}
