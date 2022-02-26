using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CapaEntidad
{
    public class xmlAccesorios
    {

		[XmlRoot(ElementName = "item")]
		public class Item
		{
			[XmlElement(ElementName = "idPlanAccesorio")]
			public Int32 IdPlanAccesorio { get; set; }
			[XmlElement(ElementName = "cNombre")]
			public string CNombre { get; set; }
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
