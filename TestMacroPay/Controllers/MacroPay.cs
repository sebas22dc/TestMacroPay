using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestMacroPay.Models;

namespace TestMacroPay.Controllers
{
    [ApiController]
    [Route("Api/v1")]
    public class MacroPay : ControllerBase
    {
        List<AdressBook> Db = new List<AdressBook>();

        [HttpGet]
        [Route("contacts")]
        public List<AdressBook> contacts([FromQuery] string? phrase = "")
        {
            if (phrase != null)
            {
                Db.Add(new AdressBook { name = phrase });
            }
            return Db;
        }
    }
}
