using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfaIntegradoCom.Funciones.Models
{
    public class SetAvailableTemplatesRequest
    {
        public IList<PrintingTemplate> Templates { get; set; } = new List<PrintingTemplate>();     
    }
}
