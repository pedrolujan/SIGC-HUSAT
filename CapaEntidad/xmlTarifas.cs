using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CapaEntidad
{
    public class xmlTarifas
    {
		[XmlRoot(ElementName = "item")]
		public class Item
		{
			[XmlElement(ElementName = "idTarifa")]
			public Int32 IdTarifa { get; set; }
			[XmlElement(ElementName = "idTipoTarifa")]
			public Int32 IdTipoTarifa { get; set; }
			[XmlElement(ElementName = "precioEquipo")]
			public Double PrecioEquipo { get; set; }
			[XmlElement(ElementName = "precioPlan")]
			public Double PrecioPlan { get; set; }
			[XmlElement(ElementName = "precioRenovaciones")]
			public Double PrecioRenovaciones { get; set; }
			[XmlElement(ElementName = "cSimbolo")]
			public String SimboloMoneda { get; set; }
		}

		[XmlRoot(ElementName = "items")]
		public class Items
		{
			[XmlElement(ElementName = "item")]
			public List<Item> Item { get; set; }
		}
	}
}
