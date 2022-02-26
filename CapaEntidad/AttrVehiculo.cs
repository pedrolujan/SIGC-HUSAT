using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetalleVehiculoEspecial
    {
        public DetalleVehiculoEspecial() { }

        Int32 _idDetVehiculoEsp = 0;
        public Int32 idDetVehiculoEsp { get { return _idDetVehiculoEsp; } set { _idDetVehiculoEsp = value; } }

        String _cNomDetVehiculoEsp = "";
        public String cNomDetVehiculoEsp { get { return _cNomDetVehiculoEsp; } set { _cNomDetVehiculoEsp = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        DateTime _dFechaReg;
        public DateTime dFechaReg { get { return _dFechaReg; } set { _dFechaReg = value; } }



        public DetalleVehiculoEspecial(Int32 pidDetVehiculo, String pcNomDetVehiculo, Boolean pbEstado)
        {
            idDetVehiculoEsp = pidDetVehiculo;
            cNomDetVehiculoEsp = pcNomDetVehiculo;
            bEstado = pbEstado;
        }
        public DetalleVehiculoEspecial(Int32 pidDetVehiculo, String pcNomDetVehiculo)
        {
            idDetVehiculoEsp = pidDetVehiculo;
            cNomDetVehiculoEsp = pcNomDetVehiculo;
        }
    }

    public class ClaseVehiculo
    {
        public ClaseVehiculo() { }

        Int32 _idClase = 0;
        public Int32 idClase { get { return _idClase; } set { _idClase = value; } }

        String _cNomClase = "";
        public String cNomClase { get { return _cNomClase; } set { _cNomClase = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        Boolean _bConPlaca = false;
        public Boolean bConPlaca { get { return _bConPlaca; } set { _bConPlaca = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        DateTime _dFechaReg;
        public DateTime dFechaReg { get { return _dFechaReg; } set { _dFechaReg = value; } }



        public ClaseVehiculo(Int32 pidClase, String pcNomClase, Boolean pbEstado)
        {
            idClase = pidClase;
            cNomClase = pcNomClase;
            bEstado = pbEstado;
        }
        public ClaseVehiculo(Int32 pidClase, String pcNomClase)
        {
            idClase = pidClase;
            cNomClase = pcNomClase;
        }
    }

    public class ModUsoVehiculo
    {
        public ModUsoVehiculo() { }

        Int32 _idUso = 0;
        public Int32 idUso { get { return _idUso; } set { _idUso = value; } }

        String _cUso = "";
        public String cUso { get { return _cUso; } set { _cUso = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        DateTime _dFechaReg;
        public DateTime dFechaReg { get { return _dFechaReg; } set { _dFechaReg = value; } }

        Int32 _idClase = 0;

        public Int32 idClase {get { return _idClase; } set{ _idClase = value; } }

        public ModUsoVehiculo(Int32 pidUso, String pcUso, Boolean pbEstado)
        {
            idUso = pidUso;
            cUso = pcUso;
            bEstado = pbEstado;
        }
        public ModUsoVehiculo(Int32 pidUso, String pcUso)
        {
            idUso = pidUso;
            cUso = pcUso;
        }
    }
    public class MarcaVehiculo
    {
        public MarcaVehiculo() { }

        Int32 _idMarca = 0;
        public Int32 idMarca { get { return _idMarca; } set { _idMarca = value; } }

        String _cNomMarca = "";
        public String cNomMarca { get { return _cNomMarca; } set { _cNomMarca = value; } }

        String _cNomClase = "";
        public String cNomClase { get { return _cNomClase; } set { _cNomClase = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        Int32 _idClase = 0;
        public Int32 idClase { get { return _idClase; } set { _idClase = value; } }

        DateTime _dFechaReg;
        public DateTime dFechaReg { get { return _dFechaReg; } set { _dFechaReg = value; } }



        public MarcaVehiculo(Int32 pidMarca, String pcNomMarca, Boolean pbEstado)
        {
            idMarca = pidMarca;
            cNomMarca = pcNomMarca;
            bEstado = pbEstado;
        }
        public MarcaVehiculo(Int32 pidMarca, String pcNomMarca, String pcNomClase, Boolean pbEstado)
        {
            idMarca = pidMarca;
            cNomMarca = pcNomMarca;
            cNomClase = pcNomClase;
            bEstado = pbEstado;
        }
        public MarcaVehiculo(Int32 pidMarca, String pcNomMarca, Boolean pbEstado,Int32 pnidClase)
        {
            idMarca = pidMarca;
            cNomMarca = pcNomMarca;
            bEstado = pbEstado;
            idClase = pnidClase;
        }
        public MarcaVehiculo(Int32 pidMarca, String pcNomMarca)
        {
            idMarca = pidMarca;
            cNomMarca = pcNomMarca;
        }
    }

    public class ModeloVehiculo
    {
        public ModeloVehiculo() { }

        Int32 _idModelo = 0;
        public Int32 idModelo { get { return _idModelo; } set { _idModelo = value; } }

        String _cNomModelo = "";
        public String cNomModelo { get { return _cNomModelo; } set { _cNomModelo = value; } }

        String _cNomClase = "";
        public String cNomClase { get { return _cNomClase; } set { _cNomClase = value; } }

        String _cNomMarca = "";
        public String cNomMarca { get { return _cNomMarca; } set { _cNomMarca = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        Int32 _idMarca = 0;
        public Int32 idMarca { get { return _idMarca; } set { _idMarca = value; } }

        Int32 _idClase = 0;
        public Int32 idClase { get { return _idClase; } set { _idClase = value; } }

        DateTime _dFechaReg;
        public DateTime dFechaReg { get { return _dFechaReg; } set { _dFechaReg = value; } }

        public ModeloVehiculo(Int32 pidModelo, String pcNomModelo, Boolean pbEstado)
        {
            idModelo = pidModelo;
            cNomModelo = pcNomModelo;
            bEstado = pbEstado;
        }
        public ModeloVehiculo(Int32 pidModelo, String pcNomModelo, String pcNomClase, String pcNomMarca, Boolean pbEstado)
        {
            idModelo = pidModelo;
            cNomModelo = pcNomModelo;
            cNomClase = pcNomClase;
            cNomMarca = pcNomMarca;
            bEstado = pbEstado;
        }
        public ModeloVehiculo(Int32 pidModelo, String pcNomModelo, Boolean pbEstado,Int32 pnidMarca,Int32 pnidClase)
        {
            idModelo = pidModelo;
            cNomModelo = pcNomModelo;
            bEstado = pbEstado;
            idMarca = pnidMarca;
            idClase = pnidClase;
        }
        public ModeloVehiculo(Int32 pidModelo, String pcNomModelo)
        {
            idModelo = pidModelo;
            cNomModelo = pcNomModelo;
           
        }
    }
}
