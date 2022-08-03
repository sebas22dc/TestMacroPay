using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestMacroPay.Models;
using TestMacroPay.Utilities;

namespace TestMacroPay.Controllers
{
    [ApiController]
    [Route("Api/v1")]
    public class MacroPay : ControllerBase
    {
        List<AdressBook> Db = new ReadDb().ReadFakeDb();

        [HttpGet]
        [Route("contacts")]
        public IActionResult contacts([FromQuery] string? phrase)
        {
            List<AdressBook> items = Db;
            if (phrase!= null && phrase != "")
            {
                items = Db.FindAll(I => I.name.Contains(phrase));
            }

            return Ok(items);
        }

        [HttpGet]
        [Route("contacts/{ID?}")]
        public IActionResult ContactId(string? ID = "")
        {
            AdressBook item = Db.Find(I => I.id == ID);
            if (item == null)
            {
                return NotFound("Elemento no encontrado");
            }

            return Ok(item);
        }

        [HttpDelete]
        [Route("contacts/{ID?}")]
        public IActionResult DeleteContact(string? ID = "")
        {
            AdressBook item = Db.Find(I => I.id == ID);
            if (item == null)
            {
                return NotFound("Elemento no encontrado");
            }
            new ReadDb().UpdateDeleteDb(Db.FindAll(I => I.id != ID));
            return NoContent();
        }
    }
}
