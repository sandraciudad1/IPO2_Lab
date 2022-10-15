using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace App1
{
    public sealed partial class MyUserControl1 : UserControl
    {
        DispatcherTimer dtReloj;
        public MyUserControl1()
        {
            InitializeComponent();
            eventoSaludar();
        }


        //SALUDAR
        private void eventoSaludar()
        {
            Storyboard saludar = (Storyboard)this.Resources["Saludar"];
            saludar.Begin();
        }


        

        //SUBIR ESCUDO
        private void subirEscudo(object sender, object e)
        {
            PB_escudo.Value += 1.0;
            if (PB_escudo.Value == 90)
            {
                dtReloj.Stop();
            }
        }


        //USAR ATAQUE ENCANTO
        private void UsarEncanto(object sender, object e)
        {
            Storyboard Encanto = (Storyboard)this.Resources["Encanto"];
            //Inicialización de las 4 imágenes:
            corazon1.Width = 40; corazon1.Height = 40; corazon1.Visibility = Visibility.Visible;
            corazon2.Width = 40; corazon2.Height = 40; corazon2.Visibility = Visibility.Visible;
            corazon3.Width = 40; corazon3.Height = 40; corazon3.Visibility = Visibility.Visible;
            corazon4.Width = 40; corazon4.Height = 40; corazon4.Visibility = Visibility.Visible;
            Encanto.Begin();
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(100);
            dtReloj.Tick += subirVida;
            dtReloj.Start();
        }

        //SUBIR VIDA
        private void subirVida(object sender, object e)
        {
            PB_corazon.Value += 1.0;
            if (PB_corazon.Value == 100)
            {
                dtReloj.Stop();
            }
        }


        //USAR ATAQUE GRUNÑIDO
        private void UsarGrunido(object sender, object e)
        {
            Storyboard Grunido = (Storyboard)this.Resources["Grunido"];
            //Inicialización de las 4 imágenes:
            rayo1.Width = 40; rayo1.Height = 40; rayo1.Visibility = Visibility.Visible;
            rayo2.Width = 40; rayo2.Height = 40; rayo2.Visibility = Visibility.Visible;
            rayo3.Width = 40; rayo3.Height = 40; rayo3.Visibility = Visibility.Visible;
            rayo4.Width = 40; rayo4.Height = 40; rayo4.Visibility = Visibility.Visible;
            Grunido.Begin();
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(100);
            dtReloj.Tick += bajarEscudo;
            dtReloj.Start();
        }

        //BAJAR ESCUDO
        private void bajarEscudo(object sender, object e)
        {
            PB_escudo.Value -= 1.0;
            if (PB_escudo.Value == 30)
            {
                dtReloj.Stop();
            }
        }


        //USAR ATAQUE DOBLO FILO
        private void UsarDobleFilo(object sender, object e)
        {
            Storyboard dobleFilo = (Storyboard)this.Resources["dobleFilo"];
            dobleFilo.Begin();
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(100);
            dtReloj.Tick += bajarVida;
            dtReloj.Start();
        }

        //BAJAR VIDA
        private void bajarVida(object sender, object e)
        {
            PB_corazon.Value -= 1.0;
            if (PB_corazon.Value == 40)
            {
                dtReloj.Stop();
            }

        }


    }
}
