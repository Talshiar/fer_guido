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
        public IEnumerable<Baza.TypeOfPlace> TypeOfPlace { get; set; }
        public IEnumerable<Baza.Route> Route { get; set; }

    }
}