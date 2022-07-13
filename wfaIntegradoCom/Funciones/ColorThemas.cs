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

        public static Color PanelPadre;
        public static Color PanelBotones;
        public static Color BarraAccesoDirectos;
        public static Color Fuente_Icones;


        //colores Defecto
        private static readonly Color PanelPadreD = Color.FromArgb(244, 129, 103);
        private static readonly Color PanelBotonesD = Color.FromArgb(255, 72, 31);
        private static readonly Color BarraAccesoDirectosD = Color.FromArgb(217, 61, 26);
        private static readonly Color Fuente_IconesD = Color.FromArgb(255, 72, 31);


        //colores Darck
        private static readonly Color PanelPadreDarck = Color.FromArgb(32, 32, 32);
        private static readonly Color PanelBotonesDarck = Color.FromArgb(25, 25, 25);
        private static readonly Color BarraAccesoDirectosDarck = Color.FromArgb(61, 61, 61);
        private static readonly Color Fuente_IconesDarck = Color.FromArgb(25, 25, 25);

        //colores Pink
        private static readonly Color PanelPadrePink = Color.FromArgb(252, 197, 192);
        private static readonly Color PanelBotonesPink = Color.FromArgb(198, 137, 198);
        private static readonly Color BarraAccesoDirectosPink = Color.FromArgb(147, 125, 194);
        private static readonly Color Fuente_IconesPink = Color.FromArgb(232, 160, 191);

        //Aplicando colores a las Areas
        #region --> Methodos
        public static void ElegirThema(String Tema)
        {
            if (Tema == "Defecto")
            {
                PanelPadre = PanelPadreD;
                PanelBotones = PanelBotonesD;
                BarraAccesoDirectos = BarraAccesoDirectosD;
                Fuente_Icones = Fuente_IconesD;

            }
            if (Tema == "Darck")
            {
                PanelPadre = PanelPadreDarck;
                PanelBotones = PanelBotonesDarck;
                BarraAccesoDirectos = BarraAccesoDirectosDarck;
                Fuente_Icones = Fuente_IconesDarck;
            }

            if (Tema == "Pink")
            {
                PanelPadre = PanelPadrePink;
                PanelBotones = PanelBotonesPink;
                BarraAccesoDirectos = BarraAccesoDirectosPink;
                Fuente_Icones = Fuente_IconesPink;
            }

        }





        #endregion

    }
}
