using System;
using System.Collections.Generic;
using System.Text;

namespace LOVA.Models
{
    public class Starwars
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }
    }
}
