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
    public class DebitController : ControllerBase
    {
        private readonly DebitService _debitService;

        public DebitController (DebitService debitService)
        {
            _debitService = debitService;
        }

        [HttpGet]
        public ActionResult<List<Debit>> Get() =>
            _debitService.Get();
        
        [HttpGet("{id:length(24)}", Name = "GetDebit" )]
        public ActionResult<Debit> Get(string id)
        {
            var debit = _debitService.Get(id);

            if (debit == null)
            {
                return NotFound();
            }
            return debit;
        }

        [HttpPost]
        public ActionResult<Debit> Create(Debit debit)
        {
            _debitService.Create(debit);

            return CreatedAtRoute("GetDebit", new { id = debit.Id.ToString()}, debit);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Debit debitIn)
        {
            var debit = _debitService.Get(id);
            if (debit == null)
            {
                return NotFound();
            }
            _debitService.Update(id, debitIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var debit = _debitService.Get(id);
            if (debit == null)
            {
                return NotFound();
            }
            _debitService.Remove(debit.Id);
            return NoContent();
        }

    }
}
