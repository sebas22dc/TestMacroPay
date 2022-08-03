﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
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
        public IActionResult contacts()
        {
            var QueryParams = ControllerContext.HttpContext.Request.Query;
            if (QueryParams.TryGetValue("phrase", out StringValues value))
            {
                if (string.IsNullOrEmpty(value))
                {
                    return BadRequest("Error en la solicitud");
                }
            }
            string phrase = value.ToString();
            List<AdressBook> items = Db;
            if (phrase != null && phrase != "")
            {
                items = Db.FindAll(I => I.name.ToLower().Contains(phrase.ToLower()));
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
