using System;
using CrossSiteScripting.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrossSiteScripting.Controllers
{
    public class BoardGameController : ApiController
    {

       BoardGame[] products = new BoardGame[]
       {
            new BoardGame { Id = 1, Name = "Chess", Category = "Strategy", Mechanic = "Board", Genre = "Classic" },
            new BoardGame { Id = 2, Name = "Munchkin", Category = "Card", Mechanic = "Dice", Genre = "Medieval" }

       };

        public IEnumerable<BoardGame> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
