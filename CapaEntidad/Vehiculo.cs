using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Vehiculo
    {
        public Vehiculo()
        { }

        Int32 _idVehiculo = 0;
        public Int32 idVehiculo { get { return _idVehiculo; } set { _idVehiculo = value; } }

        
        String _vPlaca = "";
        public String vPlaca { get { return _vPlaca; } set { _vPlaca = value; } }

        Int32 _idClase=0;
        public Int32 idClase { get { return _idClase; } set { _idClase = value; } }

        Int32 _idDescriVehiculoEsp = 0;
        public Int32 idDescriVehiculoEsp { get { return _idDescriVehiculoEsp; } set { _idDescriVehiculoEsp = value; } }

        String _vClase = "";
        public String vClase { get { return _vClase; } set { _vClase = value; } }

        Int32 _vMarca = 0;
        public Int32 idMarcaV { get { return _vMarca; } set { _vMarca = value; } }

        Int32 _vModelo = 0;
        public Int32 idModeloV { get { return _vModelo; } set { _vModelo = value; } }

        String _vMarcaV = "";
        public String vMarcaV { get { return _vMarcaV; } set { _vMarcaV = value; } }

        String _vModeloV = "";
        public String vModeloV { get { return _vModeloV; } set { _vModeloV = value; } }

        String _vSerie = "";
        public String vSerie { get { return _vSerie; } set { _vSerie = value; } }
       
        Int32 _vAnio = 0;
        public Int32 anio { get { return _vAnio; } set { _vAnio = value; } }

        String _vColor = "";
        public String vColor { get { return _vColor; } set { _vColor = value; } }

        String _vModUso = "";
        public String vModUso { get { return _vModUso; } set { _vModUso = value; } }

        String _Observaciones = "";
        public String Observaciones { get { return _Observaciones; } set { _Observaciones = value; } }
        String _Propietario = "";
        public String Propietario { get { return _Propietario; } set { _Propietario = value; } }

        Int32 _ModoUso = 0;
        public Int32 ModoUso { get { return _ModoUso; } set { _ModoUso = value; } }
        Int32 _idCliente = 0;
        public Int32 idCliente { get { return _idCliente; } set { _idCliente = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }
        
        DateTime _dFechaReg;
        public DateTime dFechaReg { get { return _dFechaReg; } set { _dFechaReg = value; } }
        public Vehiculo(Int32 pnidVehiculo, Int32 pnidClase, String pcPlacV, String pcPropietario)
        {
            idVehiculo = pnidVehiculo;
            idClase = pnidClase;
            vPlaca = pcPlacV;
            Propietario = pcPropietario;
        }
        public Vehiculo(Int32 pnidVehiculo, String pcClase, String pcPlacV, String pcPropietario)
        {
            idVehiculo = pnidVehiculo;
            vClase = pcClase;
            vPlaca = pcPlacV;
            Propietario = pcPropietario;
        }

        public Vehiculo(Int32 pnidVehiculo, String pcPropietario, String pcPlacV, String pcNomMarca, String pcNomModelo, String pcClase, String pcUso,Boolean pbEstado)
        {
            idVehiculo = pnidVehiculo;
            Propietario = pcPropietario;
            vPlaca = pcPlacV;
            vMarcaV = pcNomMarca;
            vModeloV = pcNomModelo;
            vClase = pcClase;
            vModUso = pcUso;
            bEstado = pbEstado;
        }




        public Vehiculo(Int32 pnidVehiculo, Int32 pnidClase)
        {
            idVehiculo = pnidVehiculo;
            idClase = pnidClase;
        }

        public Vehiculo(Int32 pnidVehiculo, Int32 pnidClase, String pcPlacV,Int32 pnidMarcaV, Int32 pnidModeloV, Int32 pnidModoUsoV, String pcSerieV, Int32 pnAnio, String pcColorV, Int32 pnidCliente,String pcObservaciones)
        {
            idVehiculo = pnidVehiculo;
            idClase = pnidClase;
            vPlaca = pcPlacV;
            idMarcaV = pnidMarcaV;
            idModeloV = pnidModeloV;
            vSerie = pcSerieV;
            anio = pnAnio;
            vColor = pcColorV;
            ModoUso = pnidModoUsoV;
            idCliente = pnidCliente;
            Observaciones = pcObservaciones;
        }

        public static Vehiculo fnObtenerVehiculoSeleccionado(Int32 idVehiculo, List<Vehiculo> lstV)
        {
            foreach (Vehiculo item in lstV)
            {
                if (item.idVehiculo == idVehiculo)
                {
                    return item;
                }
            }
            return new Vehiculo();
        }

    }
    public class VehiculoYCliente
    {
        public VehiculoYCliente()
        { }

        Int32 _idVehiculo;
        public Int32 idVehiculo { get { return _idVehiculo; } set { _idVehiculo = value; } }
        String _placa;
        public String placa { get { return _placa; } set { _placa = value; } }

        String _claseVehiculo;
        public String claseVehiculo { get { return _claseVehiculo; } set { _claseVehiculo = value; } }

        String _marcaVehiculo;
        public String marcaVehiculo { get { return _marcaVehiculo; } set { _marcaVehiculo = value; } }

        String _modeloVehiculo;
        public String modeloVehiculo { get { return _modeloVehiculo; } set { _modeloVehiculo = value; } }

        Int32 _idCliente;
        public Int32 idCliente { get { return _idCliente; } set { _idCliente = value; } }

        Int32 _documento;
        public Int32 documento { get { return _documento; } set { _documento = value; } }

        String _nombreCliente;
        public String nombreCliente { get { return _nombreCliente; } set { _nombreCliente = value; } }
    
        public VehiculoYCliente(Int32 pnidVehiculo,String pnPlaca,String pnClaseVehiculo,String pnMarcaVehiculo,String pnModeloVehiculo,Int32 pnidCliente,Int32 pnDocumento ,String pnNombreCliente)
        {
            idVehiculo = pnidVehiculo;
            placa = pnPlaca;
            claseVehiculo = pnClaseVehiculo;
            marcaVehiculo = pnMarcaVehiculo;
            modeloVehiculo = pnModeloVehiculo;
            idCliente = pnidCliente;
            documento = pnDocumento;
            nombreCliente = pnNombreCliente;
        }
    }

    public class DatosEnviarVehiculo
    {
        public String busqueda { get; set; }
        public Boolean estPropietario { get; set; }
        public Boolean estPlaca { get; set; }
        public Boolean estVehMenor { get; set; }
        public Boolean estVehMayor { get; set; }

    }
}
