using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFetchAPI.Models
{
    public class MServerError
    {

        public bool HasServerError { get; set; }
        public string JSONString { get; set; }

        public string? Message { get; set; }
    }
}
