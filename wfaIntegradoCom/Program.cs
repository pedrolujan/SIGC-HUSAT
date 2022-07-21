using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Mantenedores;
using wfaIntegradoCom.Procesos;

namespace wfaIntegradoCom
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmRegistrarUbigeo());
            //Application.Run(new frmRegistrarAccesorios());
            //Application.Run(new frmRegistrarPlanes());
            //Application.Run(new frmBuscarCliente());
            //Application.Run(new frmRegistrarMarcaVehiculo());
            //Application.Run(new frmRegistrarEquipoGps());
            //Application.Run(new frmDocumentoVenta());
            Application.Run(new MDIParent1());
            //Application.Run(new frmEmpleado());
            //Application.Run(new frmRegistrarVehiculo());
            //Application.Run(new frmLoad());


        }

    }                                                         
}
