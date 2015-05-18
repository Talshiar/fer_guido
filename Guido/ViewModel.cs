using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guido
{
    public class ViewModel
    {
        public IEnumerable<Baza.City> City { get; set; }
        public IEnumerable<Baza.Place> Place { get; set; }

    }
}