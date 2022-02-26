using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CapaEntidad
{
    public class xmlTiposPlan
    {

		[XmlRoot(ElementName = "item")]
		public class Item
		{
			[XmlElement(ElementName = "idTipoPlan")]
			public string IdTipoPlan { get; set; }
			[XmlElement(ElementName = "cNombre")]
			public string CNombre { get; set; }
		}

		[XmlRoot(ElementName = "items")]
		public class Items
		{
			[XmlElement(ElementName = "item")]
			public List<Item> Item { get; set; }
		}
	}
}
