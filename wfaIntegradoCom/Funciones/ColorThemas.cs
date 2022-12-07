using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace wfaIntegradoCom.Funciones
{
    public static class ColorThemas
    {

        public static Color PanelPadre;//panel principal centro
        public static Color PanelBotones;//Fondo del panel de los botones
        public static Color BarraAccesoDirectos;//Fondo del panel de botones de accesoDirectos
        public static Color contenidoDasboard;//Fondo del panel de botones de accesoDirectos
        public static Color FondoControles;//Fondo del panel de botones de accesoDirectos
        public static Color FuenteControles;//Fondo del panel de botones de accesoDirectos
       
      
        public static Color IconoBotones;//Color de los iconos cuando estan inactivo
        public static Color FuenteBotones;//Color de los iconos cuando estan inactivos

        public static Color FondoBotones;//Fondo cuando el boton esta inactivo

        //colores Defecto
        private static readonly Color PanelPadreD = Color.FromArgb(229, 229, 229);
        private static readonly Color PanelBotonesD = Color.FromArgb(255, 255, 255);
        private static readonly Color BarraAccesoDirectosD = Color.FromArgb(255, 255, 255);
        private static readonly Color FondoControlesD = Color.FromArgb(240, 240, 240);
        private static readonly Color FuenteControlesD = Color.FromArgb(105, 105, 105);
        private static readonly Color contenidoDasboardD = Color.FromArgb(255, 255, 255);
        private static readonly Color IconoBotonesD = Color.FromArgb(255, 72, 31);
        private static readonly Color FuenteBotonesD = Color.FromArgb(16,16,16);
     
        private static readonly Color FondoBotonesD = Color.FromArgb(255, 72, 31);

        //colores orange
        private static readonly Color PanelPadreO = Color.FromArgb(244, 129, 103);
        private static readonly Color PanelBotonesO = Color.FromArgb(255, 72, 31);
        private static readonly Color FondoControlesO = Color.FromArgb(163, 92, 76);
        private static readonly Color FuenteControlesO = Color.FromArgb(255, 255, 255);
        private static readonly Color BarraAccesoDirectosO = Color.FromArgb(217, 61, 26);
        private static readonly Color contenidoDasboardO = Color.FromArgb(217, 61, 26);
        private static readonly Color IconoBotonesO = Color.FromArgb(255, 255, 255);
        private static readonly Color FuenteBotonesO = Color.FromArgb(255, 255, 255);
        private static readonly Color FondoBotonesO = Color.FromArgb(255, 255, 255);


        //colores Darck
        private static readonly Color PanelPadreDarck = Color.FromArgb(30, 30, 30);
        private static readonly Color FondoControlesDarck = Color.FromArgb(79, 79, 79);
        private static readonly Color FuenteControlesDarck = Color.FromArgb(229, 229, 229);
        private static readonly Color PanelBotonesDarck = Color.FromArgb(25, 25, 25);
        private static readonly Color BarraAccesoDirectosDarck = Color.FromArgb(61, 61, 61);
        private static readonly Color contenidoDasboardDarck = Color.FromArgb(61, 61, 61);
        private static readonly Color IconoBotonesDarck = Color.FromArgb(255, 255, 255);
        private static readonly Color FuenteBotonesDarck = Color.FromArgb(255, 255, 255);
        private static readonly Color FondoBotonesDarck = Color.FromArgb(255, 255, 255);

        //colores Pink
        private static readonly Color PanelPadrePink = Color.FromArgb(92, 69, 92);
        private static readonly Color PanelBotonesPink = Color.FromArgb(124, 85, 124);
        private static readonly Color FondoControlesPink = Color.FromArgb(157, 143, 157);
        private static readonly Color FuenteControlesPink = Color.FromArgb(236, 215, 236);
        private static readonly Color BarraAccesoDirectosPink = Color.FromArgb(124, 85, 124);
        private static readonly Color contenidoDasboardPink = Color.FromArgb(185, 128, 185);
        private static readonly Color IconoBotonesP = Color.FromArgb(255, 255, 255);
        private static readonly Color FuenteBotonesP = Color.FromArgb(255, 255, 255);
        private static readonly Color FondoBotonesP = Color.FromArgb(255, 255, 255);

        //Aplicando colores a las Areas
        #region --> Methodos
        public static void ElegirThema(String Tema)
        {
            if (Tema == "CTHT0001")
            {
                PanelPadre = PanelPadreD;
                PanelBotones = PanelBotonesD;
                BarraAccesoDirectos = BarraAccesoDirectosD;  
                FondoControles = FondoControlesD;
                FuenteControles = FuenteControlesD; 
                contenidoDasboard = contenidoDasboardD;
                IconoBotones = IconoBotonesD;
                FuenteBotones = FuenteBotonesD;
             
                FondoBotones = FondoBotonesD;

            }
            if (Tema == "CTHT0003")
            {
                PanelPadre = PanelPadreO;
                PanelBotones = PanelBotonesO;
                BarraAccesoDirectos = BarraAccesoDirectosO;
                FondoControles= FondoControlesO;    
                FuenteControles= FuenteControlesO;  
                contenidoDasboard = contenidoDasboardO;
                IconoBotones = IconoBotonesO;
                FuenteBotones = FuenteBotonesO;
                FondoBotones = FondoBotonesO;

            }
            if (Tema == "CTHT0002")
            {
                PanelPadre = PanelPadreDarck;
                PanelBotones = PanelBotonesDarck;
                BarraAccesoDirectos = BarraAccesoDirectosDarck;
                FondoControles = FondoControlesDarck;
                FuenteControles = FuenteControlesDarck; 
                contenidoDasboard = contenidoDasboardDarck;
                IconoBotones = IconoBotonesDarck;
                FuenteBotones = FuenteBotonesDarck;
                FondoBotones = FondoBotonesDarck;
            }

            if (Tema == "CTHT0004")
            {
                PanelPadre = PanelPadrePink;
                PanelBotones = PanelBotonesPink;
                BarraAccesoDirectos = BarraAccesoDirectosPink;
                FuenteControles= FuenteControlesPink;   
                FondoControles= FondoControlesPink; 
                contenidoDasboard = contenidoDasboardPink;
                IconoBotones = IconoBotonesP;
                FuenteBotones = FuenteBotonesP;
                FondoBotones = FondoBotonesP;
            }

        }





        #endregion

    }
}
