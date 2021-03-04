using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using haushaltsbuch.Models;
using haushaltsbuch.Services;

namespace haushaltsbuch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        private readonly CreditService _creditService;

        public CreditController(CreditService creditService)
        {
            _creditService = creditService;
        }

        [HttpGet]
        public ActionResult<List<Credit>> Get() =>
            _creditService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCredit")]
        public ActionResult<Credit> Get(string id)
        {
            var credit = _creditService.Get(id);

            if (credit == null)
            {
                return NotFound();
            }

            return credit;
        }

        [HttpPost]
        public ActionResult<Credit> Create(Credit credit)
        {
            _creditService.Create(credit);

            return CreatedAtRoute("GetCredit", new { id = credit.Id.ToString() }, credit);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Credit creditIn)
        {
            var credit = _creditService.Get(id);

            if (credit == null)
            {
                return NotFound();
            }

            _creditService.Update(id, creditIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var credit = _creditService.Get(id);

            if (credit == null)
            {
                return NotFound();
            }

            _creditService.Remove(credit.Id);

            return NoContent();
        }
    }
}
