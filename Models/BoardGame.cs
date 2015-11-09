using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossSiteScripting.Models
{
    public class BoardGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public string Mechanic { get; set; }

        public string Genre { get; set; }


    }
}