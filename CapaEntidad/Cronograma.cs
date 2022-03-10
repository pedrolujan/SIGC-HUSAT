using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cronograma
    {
        public Cronograma() { }

        public Int32 idCronograma { get; set; }
        public Int32 idContrato { get; set; }
        public DateTime periodoInicio { get; set; }
        public DateTime periodoFinal { get; set; }
        public DateTime fechaRegsitro { get; set; }
        public String estado { get; set; }
        public String cDescripcion { get; set; }


    }

    public class DetalleCronograma
    {
        public DetalleCronograma() { }
        public Int32 idDetalleCronograma { get; set; }
        public Int32 numeroCuota { get; set; }
        public String descripcion { get; set; }
        public DateTime periodoInicio { get; set; }
        public DateTime periodoFinal { get; set; }
        public DateTime fechaEmision { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public DateTime fechaPago { get; set; }
        public Double precioUnitario { get; set; }
        public String sPrecioUnitario { get; set; }
        public Int32 idTipoDescuento { get; set; }
        public String strTipoDescuento { get; set; }
        public Double descuento { get; set; }
        public Double descuentoCantidad { get; set; }
        public Double descuentoPrecio { get; set; }
        public String sDescuento { get; set; }
        public Double cantidad { get; set; }
        public Double total { get; set; }
        public String sTotal { get; set; }
        public Double montoPago { get; set; }
        public String estado { get; set; }
        public DateTime fechaRegistro { get; set; }
        public Int32 idUsuario { get; set; }
        public String cSimbolo { get; set; }
        public Int32 idDetallePago { get; set; }
        public DetalleCronograma(DetalleCronograma add)
        {
            idDetalleCronograma = add.idDetalleCronograma;
            numeroCuota = add.numeroCuota;
            descripcion = add.descripcion;
            periodoInicio = add.periodoInicio;
            periodoFinal = add.periodoFinal;
            fechaEmision = add.fechaEmision;
            fechaVencimiento = add.fechaVencimiento;
            montoPago = add.montoPago;
            estado = add.estado;
            fechaRegistro = add.fechaRegistro;
            idUsuario = add.idUsuario;
        }
    }

    public class PagoPrincipal
    {
        public PagoPrincipal() { }
        public Int32 idPagoPrincipal { get; set; }
        public String nombrePago { get; set; }
        public Double precioPago { get; set; }
        
        //public PagoPrincipal(PagoPrincipal Add)
        //{
        //    nombrePago = Add.nombrePago;
        //    precioPago = Add.precioPago;
        //}
    }
}
