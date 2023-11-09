using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ResponseSunat
    {
        public ResponseSunat() { }
        public Boolean isSuccesfull { get; set; }=false;
        public string message { get; set; }
        public string codeError { get; set; }
        public string aux1 { get; set; }
        public string aux2 { get; set; }

    }
}
