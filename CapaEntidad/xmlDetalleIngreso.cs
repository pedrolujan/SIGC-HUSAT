using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CapaEntidad
{
    public class xmlDetalleIngreso
    {
		[XmlRoot(ElementName = "item")]
		public class Item
		{
			[XmlElement(ElementName = "IdEquipo")]
			public string IdEquipo { get; set; }
			[XmlElement(ElementName = "equipos")]
			public string Equipos { get; set; }
			[XmlElement(ElementName = "cantidad")]
			public Int32 Cantidad { get; set; }
			[XmlElement(ElementName = "PrecioCompra")]
			public Double PrecioCompra { get; set; }
		}

		[XmlRoot(ElementName = "items")]
		public class Items
		{
			[XmlElement(ElementName = "item")]
			public List<Item> Item { get; set; }
		}
	}
}
