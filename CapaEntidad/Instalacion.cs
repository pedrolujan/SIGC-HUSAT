using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Instalacion
    {

        public Instalacion() { }

        public Int32 tipoActa { get; set; }
        Int32 _idInstalacion = 0;
        public Int32 idInstalacion { get { return _idInstalacion; } set { _idInstalacion = value; } }

        String _codigoInstalacion = "";
        public String codigoInstalacion { get { return _codigoInstalacion; } set { _codigoInstalacion = value; } }
        public byte[] imgQr { get; set; }

        String _cUsuario = "";
        public String cUsuario { get { return _cUsuario; } set { _cUsuario = value; } }

        Int32 _idEquipo = 0;
        public Int32 idEquipo { get { return _idEquipo; } set { _idEquipo = value; } }
        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        Int32 _idAccesorio = 0;
        public Int32 idAccesorio { get { return _idAccesorio; } set { _idAccesorio = value; } }

        Int32 _idPlan = 0;
        public Int32 idPlan { get { return _idPlan; } set { _idPlan = value; } }

        Int32 _idCliente = 0;
        public Int32 idCliente { get { return _idCliente; } set { _idCliente = value; } }
        
        String _cMarcaVehiculo = "";
        public String cMarcaVehiculo { get { return _cMarcaVehiculo; } set { _cMarcaVehiculo = value; } }

        DateTime _dFecInicio;
        public DateTime dFecInicio { get { return _dFecInicio; } set { _dFecInicio = value; } }

        DateTime _dFechaIntal;
        public DateTime dFechaIntal { get { return _dFechaIntal; } set { _dFechaIntal = value; } }

        DateTime _dFecFinal;
        public DateTime dFecFinal { get { return _dFecFinal; } set { _dFecFinal = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }



        public Instalacion(Int32 pnidinstal, Int32 pnidEquipo, Int32 pnidAccesorio, Int32 pnidplan, Int32 pnidCliente, DateTime pdFecIncicio, DateTime pdFecFinal)
        {
            idInstalacion = pnidinstal;
            idEquipo = pnidEquipo;
            idAccesorio = pnidAccesorio;
            idPlan = pnidplan;
            idCliente = pnidCliente;
            dFecInicio = pdFecIncicio;
            dFecFinal = pdFecFinal;
        }
        public Instalacion(Int32 pnidCliente, String pcMarca)
        {
            idCliente = pnidCliente;
            cMarcaVehiculo = pcMarca;
        }
        public Instalacion(Int32 pnidCliente, String pcMarca, Boolean pbEstado)
        {
            idCliente = pnidCliente;
            cMarcaVehiculo = pcMarca;
            bEstado = pbEstado;
        }

        ////public Instalacion(Int32 pnidCliente, String pcApePat, String pcApeMat, String pcPrimerNom, String pcSegundoNom
        ////    , String pcDocumento, String pcDireccion, DateTime pdFecNac,
        ////    String pcTipPers, String pcTiDo, String pcTelFijo, String pcTelCelular, Boolean pbEstado,
        ////    String pcNomDep, String pcNomProv, String pcNomDist)
        ////{
        ////    idCliente = pnidCliente;
        ////    cApePat = pcApePat;
        ////    cApeMat = pcApeMat;
        ////    cPrimerNom = pcPrimerNom;
        ////    cSegundoNom = pcSegundoNom;
        ////    cDocumento = pcDocumento;
        ////    cDireccion = pcDireccion;
        ////    dFecNac = pdFecNac;
        ////    cTipPers = pcTipPers;
        ////    cTiDo = pcTiDo;
        ////    cTelFijo = pcTelFijo;
        ////    cTelCelular = pcTelCelular;
        ////    bEstado = pbEstado;
        ////    cNomDep = pcNomDep;
        ////    cNomProv = pcNomProv;
        ////    cNomDist = pcNomDist;
        ////}

    }
    public class xmlInstalacion
    {
        public xmlInstalacion() { }

      
        public List<Cliente>ListaCliente { get; set; }
        public List<Vehiculo> ListaVehiculo { get; set; }
        public List<Equipo_imeis> ListaEquipo { get; set; }
        public List<Equipo_imeis> ListaEquipoActual { get; set; }
        public List<Plan>ListaPlan { get; set; }
        public List<AccesoriosEquipo> ListaAccesorio { get; set; }
        public List<ServicioEquipo> ListaServicio { get; set; }
        public List<UbicacionEquipoInstalacion> ListaUbicacionEquipo { get; set; }
        public Instalacion clsInstalacion { get; set; }
        public String observaciones { get; set; }
      
        
      

    }

   


    public class AccesoriosEquipo
    {
        public AccesoriosEquipo() { }

        Boolean _checkAccesorio = false;

        public Boolean checkAccesorio { get { return _checkAccesorio; } set { _checkAccesorio = value; } }

        Int32 _idAccesorios = 0;
        public Int32 idAccesorios { get { return _idAccesorios; } set { _idAccesorios = value; } }

        String _NombreAccesorio = "";
        public String NombreAccesorio { get{ return _NombreAccesorio; } set{ _NombreAccesorio = value; } }

    }

    public class ServicioEquipo
    {
        public ServicioEquipo() { }

        Boolean _checkServicio = false;

        public Boolean checkServicio { get { return _checkServicio; } set { _checkServicio = value; } }

        Int32 _idServicios = 0;
        public Int32 idServicios { get { return _idServicios; } set { _idServicios = value; } }

        String _NombreServicio = "";
        public String NombreServicio { get { return _NombreServicio; } set { _NombreServicio = value; } }

    }
    public class UbicacionEquipoInstalacion
    {
        public UbicacionEquipoInstalacion() { }

        Int32 _idUbicacionEquipo = 0;
        public Int32 idUbicacionEquipo { get { return _idUbicacionEquipo; } set { _idUbicacionEquipo = value; } }

        String _NUbicacionEquipo = "";
        public String NUbicacionEquipo { get { return _NUbicacionEquipo; } set { _NUbicacionEquipo = value; } }





        public UbicacionEquipoInstalacion(Int32 idUbicacionE, String NUbicacionE)
        {
            idUbicacionEquipo = idUbicacionE;
            NUbicacionEquipo = NUbicacionE;

        }

       
    }


}
