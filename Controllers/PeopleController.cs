using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PeopleApi.Models;
using PeopleApi.Services;

namespace PeopleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleService _peopleService;

        public PeopleController(PeopleService peopleService) => _peopleService = peopleService;

        [HttpGet]
        public ActionResult<List<People>> Get() => _peopleService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPeople")]
        public ActionResult<People> Get(string id)
        {
            var person = _peopleService.Get(id);
            if (person == null)
                return NotFound();
            return person;
        }

        [HttpPost]
        public ActionResult<People> Create(People p)
        {
            _peopleService.Create(p);
            return CreatedAtRoute("GetPeople", new { id = p.Id.ToString() }, p);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, People p)
        {
            var person = _peopleService.Get(id);
            if (person == null)
                return NotFound();
            _peopleService.Update(id, p);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var p = _peopleService.Get(id);

            if (p == null)
                return NotFound();

            _peopleService.Remove(p.Id);
            return NoContent();
        }
    }
}
