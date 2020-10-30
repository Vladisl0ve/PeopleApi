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
    public class PeopleModel : PageModel
    {
        List<People> people = new List<People>();

        public void OnGet()
        {
            var service = new PeopleService();
        }
    }
}
