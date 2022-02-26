using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CapaEntidad
{
    public class xmlAccesorio
    {

		[XmlRoot(ElementName = "item")]
		public class Item
		{
			[XmlElement(ElementName = "idEquipoAccesorio")]
			public Int32 IdEquipoAccesorio { get; set; }
			[XmlElement(ElementName = "cNombre")]
			public String CNombre { get; set; }
			[XmlElement(ElementName = "bEstado")]
			public Boolean BEstado { get; set; }
		}

		[XmlRoot(ElementName = "items")]
		public class Items
		{
			[XmlElement(ElementName = "item")]
			public List<Item> Item { get; set; }
		}
	}
}
