using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class CategoriaEquipo
    {
        public CategoriaEquipo() { }

        Int32 _idCategoria = 0;
        public Int32 idCategoria { get { return _idCategoria; } set { _idCategoria = value; } }

        String _cNomCategoria = "";
        public String cNomCategoria { get { return _cNomCategoria; } set { _cNomCategoria = value; } }

        String _cDescripCategoria = "";
        public String cDescripCategoria { get { return _cDescripCategoria; } set { _cDescripCategoria = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        DateTime _dFechaReg;
        public DateTime dFechaReg { get { return _dFechaReg; } set { _dFechaReg = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }


        public CategoriaEquipo(Int32 pidCateg, String pcNomCateg, String pcDescripcion, Boolean pbEstado)
        {
            idCategoria = pidCateg;
            cNomCategoria = pcNomCateg;
            bEstado = pbEstado;
            cDescripCategoria = pcDescripcion;
        }
        public CategoriaEquipo(Int32 pidCateg, String pcNomCateg, String cDescrip, Boolean pbEstado,DateTime pdfechaReg,Int32 pnIdUsuario)
        {
            idCategoria = pidCateg;
            cNomCategoria = pcNomCateg;
            cDescripCategoria = cDescrip;
            bEstado = pbEstado;
            dFechaReg = pdfechaReg;
            idUsuario = pnIdUsuario;
        }
        public CategoriaEquipo(Int32 pidCateg, String pcNomCateg)
        {
            idCategoria = pidCateg;
            cNomCategoria = pcNomCateg;
        }
    }

    public class MarcaEquipo
    {
        public MarcaEquipo() { }

        Int32 _idMarca = 0;
        public Int32 idMarca  { get { return _idMarca; } set { _idMarca = value; } }

        String _cNomMarca = "";
        public String cNomMarca { get { return _cNomMarca; } set { _cNomMarca = value; } }

        String _cDescripCategoria = "";
        public String cDescripMarca { get { return _cDescripCategoria; } set { _cDescripCategoria = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        DateTime _dFechaReg;
        public DateTime dFechaReg { get { return _dFechaReg; } set { _dFechaReg = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        Int32 _idCategoria = 0;
        public Int32 idCategoria { get { return _idCategoria; } set { _idCategoria = value; } }

        public MarcaEquipo(Int32 pidMarca, String pcNomMarca, Boolean pbEstado)
        {
            idMarca = pidMarca;
            cNomMarca = pcNomMarca;
            bEstado = pbEstado;
        }
        public MarcaEquipo(Int32 pidMarca, String pcNomMarca, String cDescrip, Boolean pbEstado, DateTime pdfechaReg, Int32 pnIdUsuario)
        {
            idMarca = pidMarca;
            cNomMarca = pcNomMarca;
            cDescripMarca = cDescrip;
            bEstado = pbEstado;
            dFechaReg = pdfechaReg;
            idUsuario = pnIdUsuario;
        }
        public MarcaEquipo(Int32 pidMarca, String pcNomMarca)
        {
            idMarca = pidMarca;
            cNomMarca = pcNomMarca;
        }

    }

    public class ModeloEquipo
    {
        public ModeloEquipo() { }

        Int32 _idModelo = 0;
        public Int32 idModelo { get { return _idModelo; } set { _idModelo = value; } }

        Int32 _idCategoria = 0;
        public Int32 idCategoria { get { return _idCategoria; } set { _idCategoria = value; } }
        String _cNomModelo = "";
        public String cNomModelo { get { return _cNomModelo; } set { _cNomModelo = value; } }

        String _cDescripModelo = "";
        public String cDescripModelo { get { return _cDescripModelo; } set { _cDescripModelo = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        DateTime _dFechaReg;
        public DateTime dFechaReg { get { return _dFechaReg; } set { _dFechaReg = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        Int32 _idMarca = 0;
        public Int32 idMarca { get { return _idMarca; } set { _idMarca = value; } }
        public ModeloEquipo(Int32 pidModelo, String pcNomModelo, Boolean pbEstado)
        {
            idModelo = pidModelo;
            cNomModelo = pcNomModelo;
            bEstado = pbEstado;
        }
        public ModeloEquipo(Int32 pidModelo,Int32 pcIdCategoria,Int32 pcIdMarca, String pcNomModelo, String cDescrip, Boolean pbEstado, DateTime pdfechaReg, Int32 pnIdUsuario)
        {
            idModelo = pidModelo;
            idCategoria = pcIdCategoria;
            idMarca = pcIdMarca;
            cNomModelo = pcNomModelo;
            cDescripModelo = cDescrip;
            bEstado = pbEstado;
            dFechaReg = pdfechaReg;
            idUsuario = pnIdUsuario;
        }
        public ModeloEquipo(Int32 pidModelo, String pcNomModelo)
        {
            idModelo = pidModelo;
            cNomModelo = pcNomModelo;
        }

    }


}
