using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CapaEntidad
{
    public class XmlEquiposProspecto
    {

		[XmlRoot(ElementName = "item")]
		public class Item
		{
			[XmlElement(ElementName = "idPlanEquipo")]
			public Int32 IdPlanEquipo { get; set; }
			[XmlElement(ElementName = "Equipos")]
			public String Equipos { get; set; }
			[XmlElement(ElementName = "cPrecio")]
			public Double CPrecio { get; set; }
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
