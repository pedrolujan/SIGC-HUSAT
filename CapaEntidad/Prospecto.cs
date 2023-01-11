using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Prospecto
    {
        public Prospecto() { }

        Int32 _idProspecto = 0;
        public Int32 idProspecto { get { return _idProspecto; } set { _idProspecto = value; } }

        String _nombres = "";
        public String nombres { get { return _nombres; } set { _nombres = value; } }

        String _apellidos = "";
        public String apellidos { get { return _apellidos; } set { _apellidos = value; } }

        String _celular1 = "";
        public String celular1 { get { return _celular1; }set { _celular1 = value; } }

        String _celular2 = "";
        public String celular2 { get { return _celular2; } set { _celular2 = value; } }

        String _estadoCliente = "";
        public String estadoCliente { get { return _estadoCliente; } set { _estadoCliente = value; } }

        String _correo = "";
        public String correo { get { return _correo; } set { _correo = value; } }

        Int32 _idClase = 0;
        public Int32 idClase { get { return _idClase; }set { _idClase = value; } }

        Int32 _idModoUso = 0;
        public Int32 idModoUso { get { return _idModoUso; } set { _idModoUso = value; } }

        String _idTipoContacto = "";
        public String idTipoContacto { get { return _idTipoContacto; } set { _idTipoContacto = value; } }
        
        String _observaciones = "";
        public String observaciones { get { return _observaciones; } set { _observaciones = value; } }

        Int32 _idTipoPlan = 0;
        public Int32 idTipoPlan { get { return _idTipoPlan; } set { _idTipoPlan = value; } }

        Int32 _idPlan = 0;
        public Int32 idPlan { get { return _idPlan; } set { _idPlan = value; } }

        Int32 _idEquipo = 0;
        public Int32 idEquipo { get { return _idEquipo; } set { _idEquipo = value; } }

        Int32 _cantEquipos = 0;
        public Int32 cantEquipos { get { return _cantEquipos; } set { _cantEquipos = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; }  set { _idUsuario = value; } }

        DateTime _fechaRegistro;
        public DateTime fechaRegistro { get { return _fechaRegistro; } set { _fechaRegistro = value; } }

       
    }

    public class Reporte
    {
        public Reporte() { }


        public Int32 idUsuario { get; set; }
        public Int32 numero { get; set; }
        public Int32 SumColumns { get; set; }
        public String coddAux1 { get; set; }
        public String nombreAux1 { get; set; }
        public Double ImporteAux1 { get; set; }

        public String coddAux2 { get; set; }
        public Int32 SumRowsAux2 { get; set; }
        public String nombreAux2 { get; set; }
        public Double ImporteAux2 { get; set; }
        public Double SumImporteAux2 { get; set; }

        public String coddAux3 { get; set; }
        public String nombreAux3 { get; set; }
        public Int32 SumRowsAux3 { get; set; }
        public Double ImporteAux3 { get; set; }
        public Double SumImporteAux3 { get; set; }

        public String coddAux4 { get; set; }
        public String nombreAux4 { get; set; }
        public Int32 SumRowsAux4 { get; set; }
        public Double ImporteAux4 { get; set; }
        public Double SumImporteAux4 { get; set; }

        public String coddAux5 { get; set; }
        public String nombreAux5 { get; set; }
        public Int32 SumRowsAux5 { get; set; }
        public Double ImporteAux5 { get; set; }
        public Double SumImporteAux5 { get; set; }

        public String coddAux6 { get; set; }
        public String nombreAux6 { get; set; }
        public Int32 SumRowsAux6 { get; set; }
        public Double ImporteAux6 { get; set; }
        public Double SumImporteAux6 { get; set; }

        public String coddAux7 { get; set; }
        public String nombreAux7 { get; set; }
        public Int32 SumRowsAux7 { get; set; }
        public Double ImporteAux7 { get; set; }
        public Double SumImporteAux7 { get; set; }

        public String coddAux8 { get; set; }
        public String nombreAux8 { get; set; }
        public Int32 SumRowsAux8 { get; set; }
        public Double ImporteAux8 { get; set; }
        public Double SumImporteAux8 { get; set; }

        public String coddAux9 { get; set; }
        public String nombreAux9 { get; set; }
        public Int32 SumRowsAux9 { get; set; }
        public Double ImporteAux9 { get; set; }
        public Double SumImporteAux9 { get; set; }

        public String coddAux10 { get; set; }
        public String nombreAux10 { get; set; }
        public Int32 SumRowsAux10 { get; set; }
        public Double ImporteAux10 { get; set; }
        public Double SumImporteAux10 { get; set; }

        public String coddAux11 { get; set; }
        public String nombreAux11 { get; set; }
        public Int32 SumRowsAux11 { get; set; }
        public Double ImporteAux11 { get; set; }
        public Double SumImporteAux11 { get; set; }

        public String coddAux12 { get; set; }
        public String nombreAux12 { get; set; }
        public Int32 SumRowsAux12 { get; set; }
        public Double ImporteAux12 { get; set; }
        public Double SumImporteAux12 { get; set; }

        public Int32 IdDetalleVenta { get; set; }

        public double indicador { get; set; }
        public Decimal indicadorDes { get; set; }
        public String strIndicador { get; set; }
        public String nombreIndicador { get; set; }

        public double indiceCrecimientoImporte { get; set; }
        public double indiceCrecimientoRow { get; set; }
        public double indiceCrecimientoRowGraficos { get; set; }

        public Int32 TotalFilas { get; set; }
        public double ImporteTotalFilas { get; set; }

        public String nombreTotalFilas { get; set; }
        public Int32 SumRowsTotalFilas { get; set; }
        public double SumRowsImporteTotalFilas { get; set; }

        public double indicadorTotalFilas { get; set; }
        public String strIndicadorTotalFilas { get; set; }
        public String nombreIndicadorTotalFilas { get; set; }

        public Decimal numPorcentaje { get; set; }
        public String nombrePorcentaje { get; set; }
        public Decimal numPorcentajeTotales { get; set; }


    }
    public class ProspectosPlan
    {
        public ProspectosPlan() { }

        Int32 _idProspectoPlan = 0;
        public Int32 idProspectoPlan { get { return _idProspectoPlan; } set { _idProspectoPlan = value; } }

        String _nombres = "";
        public String nombres { get { return _nombres; } set { _nombres = value; } }

        String _apellidos = "";
        public String apellidos { get { return _apellidos; } set { _apellidos = value; } }
        String _nombresApellidos = "";
        public String nombresApellidos { get { return _nombresApellidos; } set { _nombresApellidos = value; } }

        String _celular1 = "";
        public String celular1 { get { return _celular1; } set { _celular1 = value; } }

        String _celular2 = "";
        public String celular2 { get { return _celular2; } set { _celular2 = value; } }

        String _correo = "";
        public String correo { get { return _correo; } set { _correo = value; } }

        Int32 _idProspecto = 0;
        public Int32 idProspecto { get { return _idProspecto; } set { _idProspecto = value; } }

        String _estadoCliente = "";
        public String estadoCliente { get { return _estadoCliente; } set { _estadoCliente = value; } }

        Int32 _idClase = 0;
        public Int32 idClase { get { return _idClase; } set { _idClase = value; } }

        Int32 _idModoUso = 0;
        public Int32 idModoUso { get { return _idModoUso; } set { _idModoUso = value; } }

        String _idTipoContacto = "";
        public String idTipoContacto { get { return _idTipoContacto; } set { _idTipoContacto = value; } }

        String _observaciones = "";
        public String observaciones { get { return _observaciones; } set { _observaciones = value; } }

        Int32 _idTipoPlan = 0;
        public Int32 idTipoPlan { get { return _idTipoPlan; } set { _idTipoPlan = value; } }

        Int32 _idPlan = 0;
        public Int32 idPlan { get { return _idPlan; } set { _idPlan = value; } }

        Int32 _idEquipo = 0;
        public Int32 idEquipo { get { return _idEquipo; } set { _idEquipo = value; } }

        Int32 _cantEquipos = 0;
        public Int32 cantEquipos { get { return _cantEquipos; } set { _cantEquipos = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        DateTime _fechaRegistro;
        public DateTime fechaRegistro { get { return _fechaRegistro; } set { _fechaRegistro = value; } }
        String _detallePlan = "";
        public String detallePlan { get { return _detallePlan; } set { _detallePlan = value; } }

        DateTime _fechaVisita;
        public DateTime fechaVisita { get { return _fechaVisita; } set { _fechaVisita = value; } }

        String _nombreUsuario;
        public String nombreUsuario { get { return _nombreUsuario; } set { _nombreUsuario = value; } }
        public Int32 idTarifa { get; set; }
    }

    public class Seguimiento
    {
        public Seguimiento() { }

        Int32 _idSeguimiento = 0;
        public Int32 idSeguimiento { get { return _idSeguimiento; } set { _idSeguimiento = value; } }

        Int32 _idProspectoPlan = 0;
        public Int32 idProspectoPlan { get { return _idProspectoPlan; } set { _idProspectoPlan = value; } }
        
        String _observacion = "";
        public String observacion { get { return _observacion; } set { _observacion = value; } }

        DateTime _fechaRegistro ;
        public DateTime fechaRegistro { get { return _fechaRegistro; } set { _fechaRegistro = value; } }
        
        DateTime _fechaProxSeguimiento;
        public DateTime fechaProxSeguimiento { get { return _fechaProxSeguimiento; } set { _fechaProxSeguimiento = value; } }

        Int32 _idUsuario;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        String _estadoCliente;
        public String estadoCliente { get { return _estadoCliente; } set { _estadoCliente = value; } }


    }

    public class totalRanking
    {
        public totalRanking() { }

        Int32 _totalVerdes = 0;
        public Int32 totalVerdes { get { return _totalVerdes; } set { _totalVerdes = value; } }

        Int32 _totalAmarillos = 0;
        public Int32 totalAmarillos { get { return _totalAmarillos; } set { _totalAmarillos = value; } }

        Int32 _totalRojos = 0;
        public Int32 totalRojos { get { return _totalRojos; } set { _totalRojos = value; } }
    }


}
