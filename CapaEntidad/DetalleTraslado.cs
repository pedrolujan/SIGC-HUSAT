using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetalleTraslado
    {

        public DetalleTraslado() { }

        Int32 _idDetalleTraslado = 0;
        public Int32 idDetalleTraslado { get { return _idDetalleTraslado; } set { _idDetalleTraslado = value; } }

        Int32 _idLote = 0;
        public Int32 idLote { get { return _idLote; } set { _idLote = value; } }

        string _cProducto = "";
        public String cProducto { get { return _cProducto; } set { _cProducto = value; } }

        decimal _nCantidad = 0;
        public Decimal nCantidad { get { return _nCantidad; } set { _nCantidad = value; } }

        string _cUnidadMedida = "";
        public String cUnidadMedida { get { return _cUnidadMedida; } set { _cUnidadMedida = value; } }
        
        bool _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        public DetalleTraslado(int pidDetalleTraslado, int pidLote, string pcProducto, decimal pnCantidad, string pcUnidadMedida)
        {
            idDetalleTraslado = pidDetalleTraslado;
            idLote = pidLote;
            cProducto = pcProducto;
            nCantidad = pnCantidad;
            cUnidadMedida = pcUnidadMedida;
        }

    }
}
