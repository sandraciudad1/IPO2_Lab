﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using CommunityToolkit.WinUI.Notifications;
using System.Threading;
using System.Threading.Tasks;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Combate1Jug : Page
    {
        DispatcherTimer dtReloj;
        public int turno = 1;
        public int pokemon1 = CombatePage.pokemon1;
        public int pokemon2 = CombatePage.pokemon2;
        public bool debilitado = false;
        public bool flag = false;
        public object sender;
        public object e;
        public string textoSnorlax = "";
        public string textoTogepi = "";
        public string tituloSnorlax = "";
        public string tituloTogepi = "";
        public int numero = MainPage.index;
        public Combate1Jug()
        {
            this.InitializeComponent();
            InitializeComponent();
            eventoSaludar();

            


            if (numero == 0)
            {
                lblCombate.Text = "UN JUGADOR";
                lblFondo.Text = "FONDO";
                tituloSnorlax = "¡SNORLAX DEBILITADO!";
                tituloTogepi = "¡TOGEPI DEBILITADO!";
                textoSnorlax = "No se puede realizar este movimiento porque Snorlax se ha debilitado";
                textoTogepi = "No se puede realizar este movimiento porque Togepi se ha debilitado";
            }
            else if (numero == 1)
            {
                lblCombate.Text = "SINGLE PLAYER";
                lblFondo.Text = "BACKGROUND";
                tituloSnorlax = "WEAKENED SNORLAX!";
                tituloTogepi = "TOGEPI WEAKENED!";
                textoSnorlax = "This move cannot be performed because Snorlax has been weakened.";
                textoTogepi = "Cannot perform this move because Togepi has been weakened";
            }
            else if (numero == 2)
            {
                lblCombate.Text = "EIN SPIELER";
                lblFondo.Text = "HINTERGRUND";
                tituloSnorlax = "SCHWÄCHES SNORLAX!";
                tituloTogepi = "TOGEPI GEWÄCHST!";
                textoSnorlax = "Kann diese Bewegung nicht ausführen, da Snorlax geschwächt wurde";
                textoTogepi = "Kann diese Bewegung nicht ausführen, da Togepi geschwächt wurde";
            }


            int counter = 0;
            comprobarTurnoAsync(turno);

            Storyboard sb1 = (Storyboard)this.Resources["sbSaludar"];
            while (counter < 4)
            {
                sb1.AutoReverse = true;
                sb1.Begin();
                counter++;
            }

            if (pokemon1 == 0)
            {
                frmSnorlax1.Visibility = Visibility.Visible;
                frmSnorlax1.HorizontalAlignment = HorizontalAlignment.Left;
            }
            else if (pokemon1 == 1)
            {
                frmSnorlax2.Visibility = Visibility.Visible;
                frmSnorlax2.HorizontalAlignment = HorizontalAlignment.Left;
            }
            else if (pokemon1 == 2)
            {
                frmTogepi.Visibility = Visibility.Visible;
                frmTogepi.HorizontalAlignment = HorizontalAlignment.Left;
            }

            if (pokemon2 == 0)
            {
                frmSnorlax1.Visibility = Visibility.Visible;
                frmSnorlax1.HorizontalAlignment = HorizontalAlignment.Right;
                frmSnorlax1.Visibility = Visibility.Visible;
                frmSnorlax1.HorizontalAlignment = HorizontalAlignment.Right;
                btnPlacaje.IsEnabled = false;
                btngolpeCabeza.IsEnabled = false;
                btngolpeCuerpo.IsEnabled = false;
                btnAleatorioSnorlax1.IsEnabled = false;
                Img_pocima.Visibility = Visibility.Collapsed;
            }
            else if (pokemon2 == 1)
            {
                frmSnorlax2.Visibility = Visibility.Visible;
                frmSnorlax2.HorizontalAlignment = HorizontalAlignment.Right;
                frmSnorlax2.Visibility = Visibility.Visible;
                frmSnorlax2.HorizontalAlignment = HorizontalAlignment.Right;
                btnDescanso.IsEnabled = false;
                btnDefensa.IsEnabled = false;
                btnTambor.IsEnabled = false;
                btnGolpe.IsEnabled = false;
                pocimaSnorlax2.Visibility = Visibility.Collapsed;
            }
            else if (pokemon2 == 2)
            {
                frmTogepi.Visibility = Visibility.Visible;
                frmTogepi.HorizontalAlignment = HorizontalAlignment.Right;
                frmTogepi.Visibility = Visibility.Visible;
                frmTogepi.HorizontalAlignment = HorizontalAlignment.Right;
                btnEncanto.IsEnabled = false;
                btnDobleFilo.IsEnabled = false;
                btnGrunido.IsEnabled = false;
                btnAleatorio.IsEnabled = false;
                Img_pocimaTogepi.Visibility = Visibility.Collapsed;
            }
        }

        private void comboBoxFondo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxFondo.SelectedIndex == 0)
            {
                lblCombate.Foreground = new SolidColorBrush(Colors.Black);
                fondoPantalla.Source = new BitmapImage(new Uri("ms-appx:///Assets/fondoGimnasio.png"));
            }
            else if (comboBoxFondo.SelectedIndex == 1)
            {
                lblCombate.Foreground = new SolidColorBrush(Colors.White);
                lblFondo.Foreground = new SolidColorBrush(Colors.White);
                fondoPantalla.Source = new BitmapImage(new Uri("ms-appx:///Assets/fondoBosque.jpg"));
            }
            else if (comboBoxFondo.SelectedIndex == 2)
            {
                lblCombate.Foreground = new SolidColorBrush(Colors.Black);
                lblFondo.Foreground = new SolidColorBrush(Colors.Black);
                fondoPantalla.Source = new BitmapImage(new Uri("ms-appx:///Assets/fondoNieve.jpg"));
            }
            else if (comboBoxFondo.SelectedIndex == 3)
            {
                lblCombate.Foreground = new SolidColorBrush(Colors.Black);
                lblFondo.Foreground = new SolidColorBrush(Colors.Black);
                fondoPantalla.Source = new BitmapImage(new Uri("ms-appx:///Assets/fondoNaturaleza.jpg"));
            }
            else if (comboBoxFondo.SelectedIndex == 4)
            {
                lblCombate.Foreground = new SolidColorBrush(Colors.White);
                lblFondo.Foreground = new SolidColorBrush(Colors.White);
                fondoPantalla.Source = new BitmapImage(new Uri("ms-appx:///Assets/fondoEstadio.jpg"));
            }
            else if (comboBoxFondo.SelectedIndex == 5)
            {
                lblCombate.Foreground = new SolidColorBrush(Colors.Black);
                lblFondo.Foreground = new SolidColorBrush(Colors.Black);
                fondoPantalla.Source = new BitmapImage(new Uri("ms-appx:///Assets/fondoCesped.jpg"));
            }
        }



        private async Task comprobarTurnoAsync(int turno)
        {
            comprobarDebilitado();
            if (debilitado == true)
            {
                btnPlacaje.IsEnabled = false;
                btngolpeCabeza.IsEnabled = false;
                btngolpeCuerpo.IsEnabled = false;
                btnAleatorioSnorlax1.IsEnabled = false;
                Img_pocima.Visibility = Visibility.Collapsed;

                btnDescanso.IsEnabled = false;
                btnDefensa.IsEnabled = false;
                btnTambor.IsEnabled = false;
                btnGolpe.IsEnabled = false;
                pocimaSnorlax2.Visibility = Visibility.Collapsed;

                btnEncanto.IsEnabled = false;
                btnDobleFilo.IsEnabled = false;
                btnGrunido.IsEnabled = false;
                btnAleatorio.IsEnabled = false;
                Img_pocimaTogepi.Visibility = Visibility.Collapsed;
                
            }
            else if(debilitado == false)
            {
                if (turno % 2 == 0) 
                {
                    if (pokemon1 == 0)
                    {
                        frmSnorlax1.Visibility = Visibility.Visible;
                        frmSnorlax1.HorizontalAlignment = HorizontalAlignment.Left;
                        btnPlacaje.IsEnabled = false;
                        btngolpeCabeza.IsEnabled = false;
                        btngolpeCuerpo.IsEnabled = false;
                        btnAleatorioSnorlax1.IsEnabled = false;
                        Img_pocima.Visibility = Visibility.Collapsed;
                    }
                    else if (pokemon1 == 1)
                    {
                        frmSnorlax2.Visibility = Visibility.Visible;
                        frmSnorlax2.HorizontalAlignment = HorizontalAlignment.Left;
                        btnDescanso.IsEnabled = false;
                        btnDefensa.IsEnabled = false;
                        btnTambor.IsEnabled = false;
                        btnGolpe.IsEnabled = false;
                        pocimaSnorlax2.Visibility = Visibility.Collapsed;
                    }
                    else if (pokemon1 == 2)
                    {
                        frmTogepi.Visibility = Visibility.Visible;
                        frmTogepi.HorizontalAlignment = HorizontalAlignment.Left;
                        btnEncanto.IsEnabled = false;
                        btnDobleFilo.IsEnabled = false;
                        btnGrunido.IsEnabled = false;
                        btnAleatorio.IsEnabled = false;
                        Img_pocimaTogepi.Visibility = Visibility.Collapsed;
                    }
                    if (pokemon2 == 0)
                    {
                        await Task.Delay(7500);
                        UsarAleatorioSnorlax1(sender, e);
                    } else if(pokemon2 == 1)
                    {
                        await Task.Delay(7500);
                        ataqueGolpeCuerpo(sender, e);
                    } else if(pokemon2 == 2)
                    {
                        await Task.Delay(7500);
                        UsarAleatorio(sender, e);
                    }
                }
                else 
                {
                    if (pokemon1 == 0)
                    {
                        frmSnorlax1.Visibility = Visibility.Visible;
                        frmSnorlax1.HorizontalAlignment = HorizontalAlignment.Left;
                        btnPlacaje.IsEnabled = true;
                        btngolpeCabeza.IsEnabled = true;
                        btngolpeCuerpo.IsEnabled = true;
                        btnAleatorioSnorlax1.IsEnabled = true;
                        Img_pocima.Visibility = Visibility.Visible;
                    }
                    else if (pokemon1 == 1)
                    {
                        frmSnorlax2.Visibility = Visibility.Visible;
                        frmSnorlax2.HorizontalAlignment = HorizontalAlignment.Left;
                        btnDescanso.IsEnabled = true;
                        btnDefensa.IsEnabled = true;
                        btnTambor.IsEnabled = true;
                        btnGolpe.IsEnabled = true;
                        pocimaSnorlax2.Visibility = Visibility.Visible;
                    }
                    else if (pokemon1 == 2)
                    {
                        frmTogepi.Visibility = Visibility.Visible;
                        frmTogepi.HorizontalAlignment = HorizontalAlignment.Left;
                        btnEncanto.IsEnabled = true;
                        btnDobleFilo.IsEnabled = true;
                        btnGrunido.IsEnabled = true;
                        btnAleatorio.IsEnabled = true;
                        Img_pocimaTogepi.Visibility = Visibility.Visible;
                    }
                }
            }
        }


        private void snorlax1Debilitado()
        {
            debilitado = true;
            btnPlacaje.IsEnabled = false;
            btngolpeCabeza.IsEnabled = false;
            btngolpeCuerpo.IsEnabled = false;
            btnAleatorioSnorlax1.IsEnabled = false;
            Img_pocima.Visibility = Visibility.Collapsed;
            notificacionMuerteSnorlax();
        }

        private void snorlax2Debilitado()
        {
            btnDescanso.IsEnabled = false;
            btnDefensa.IsEnabled = false;
            btnTambor.IsEnabled = false;
            btnGolpe.IsEnabled = false;
            pocimaSnorlax2.Visibility = Visibility.Collapsed;
            notificacionMuerteSnorlax();
        }

        private void togepiDebilitado()
        {
            btnEncanto.IsEnabled = false;
            btnDobleFilo.IsEnabled = false;
            btnGrunido.IsEnabled = false;
            btnAleatorio.IsEnabled = false;
            Img_pocimaTogepi.Visibility = Visibility.Collapsed;
            notificacionMuerteTogepi();
        }

        private void comprobarDebilitado()
        {

            if (pokemon1 == 0 && pokemon2 == 1)
            {
                if (PB_corazon1.Value == 0 || PB_corazonSnorlax.Value == 0)
                {
                    debilitado = true;
                    snorlax1Debilitado();
                    snorlax2Debilitado();
                }
            } else if (pokemon1 == 0 && pokemon2 == 2)
            {
                if (PB_corazon1.Value == 0)
                {
                    debilitado = true;
                    snorlax1Debilitado();
                } else if (PB_corazon.Value == 0)
                {
                    debilitado = true;
                    togepiDebilitado();
                }
            } else if (pokemon1 == 1 && pokemon2 == 0)
            {
                if (PB_corazon1.Value == 0 || PB_corazonSnorlax.Value == 0)
                {
                    debilitado = true;
                    snorlax1Debilitado();
                    snorlax2Debilitado();
                }
            } else if (pokemon1 == 1 && pokemon2 == 2)
            {
                if (PB_corazonSnorlax.Value == 0)
                {
                    debilitado = true;
                    snorlax2Debilitado();
                } else if (PB_corazon.Value == 0)
                {
                    debilitado = true;
                    togepiDebilitado();
                }
            } else if (pokemon1 == 2 && pokemon2 == 0)
            {
                if (PB_corazon1.Value == 0)
                {
                    debilitado = true;
                    snorlax1Debilitado();
                }
                else if (PB_corazon.Value == 0)
                {
                    debilitado = true;
                    togepiDebilitado();
                }
            } else if (pokemon1 == 2 && pokemon2 == 1)
            {
                if (PB_corazonSnorlax.Value == 0)
                {
                    debilitado = true;
                    snorlax2Debilitado();
                }
                else if (PB_corazon.Value == 0)
                {
                    debilitado = true;
                    togepiDebilitado();
                }
            }

        }

        private void notificacionMuerteSnorlax()
        {
            new ToastContentBuilder()
        .AddArgument("action", "muerteSnorlax")
        .AddArgument("conversationId", 9813)
        .AddText(tituloSnorlax)
        .AddText(textoSnorlax)
        .AddAppLogoOverride(new Uri("ms-appx:///Assets/muerte.png"), ToastGenericAppLogoCrop.Circle)
        .AddInlineImage(new Uri("ms-appx:///Assets/Snorlax_debilitado.png"))
        .Show();
        }

        private void notificacionMuerteTogepi()
        {
            new ToastContentBuilder()
        .AddArgument("action", "muerteTogepi")
        .AddArgument("conversationId", 9813)
        .AddText(tituloTogepi)
        .AddText(textoTogepi)
        .AddAppLogoOverride(new Uri("ms-appx:///Assets/muerte.png"), ToastGenericAppLogoCrop.Circle)
        .AddInlineImage(new Uri("ms-appx:///Assets/togepi_debilitado.jpg"))
        .Show();
        }


        //ATAQUES TOGEPI
        private void eventoSaludar()
        {
            Storyboard saludar = (Storyboard)this.Resources["Saludar"];
            saludar.Begin();
        }

        private void UsarPocimaTogepi(object sender, object e)
        {
            comprobarDebilitado();
            if (debilitado == false)
            {
                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj.Tick += subirVida;
                dtReloj.Start();
                Img_pocima.Opacity = 0.5;
                turno += 1;
                comprobarTurnoAsync(turno);
            }

        }

        private void subirVida(object sender, object e)
        {
            PB_corazon.Value += 1.0;
            if (PB_corazon.Value == 100)
            {
                dtReloj.Stop(); 
                comprobarDebilitado();
            }
        }

        private void UsarEncanto(object sender, object e)
        {

            comprobarDebilitado();
            if (debilitado == false)
            {
                Storyboard Encanto = (Storyboard)this.Resources["Encanto"];
                corazon1.Width = 40; corazon1.Height = 40; corazon1.Visibility = Visibility.Visible;
                corazon2.Width = 40; corazon2.Height = 40; corazon2.Visibility = Visibility.Visible;
                corazon3.Width = 40; corazon3.Height = 40; corazon3.Visibility = Visibility.Visible;
                corazon4.Width = 40; corazon4.Height = 40; corazon4.Visibility = Visibility.Visible;
                Encanto.Begin();
                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj.Tick += subirEscudo;
                dtReloj.Start();
                turno += 1;
                comprobarTurnoAsync(turno);
            }
        }

        private void subirEscudo(object sender, object e)
        {
            PB_escudo.Value += 1.0;
            if (PB_escudo.Value == 80)
            {
                dtReloj.Stop();
                comprobarDebilitado();
            }
        }

        private void UsarGrunido(object sender, object e)
        {

            comprobarDebilitado();
            if (debilitado == false)
            {
                Storyboard Grunido = (Storyboard)this.Resources["Grunido"];
                rayo1.Width = 40; rayo1.Height = 40; rayo1.Visibility = Visibility.Visible;
                rayo2.Width = 40; rayo2.Height = 40; rayo2.Visibility = Visibility.Visible;
                rayo3.Width = 40; rayo3.Height = 40; rayo3.Visibility = Visibility.Visible;
                rayo4.Width = 40; rayo4.Height = 40; rayo4.Visibility = Visibility.Visible;
                Grunido.Begin();
                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj.Tick += bajarEscudo;
                dtReloj.Start();
                turno += 1;
                comprobarTurnoAsync(turno);
            }
        }

        private void bajarEscudo(object sender, object e)
        {
            PB_escudoSnorlaz2.Value -= 1.0;
            PB_escudoSnorlax1.Value -= 1.0;
            if (PB_escudoSnorlaz2.Value == 30 || PB_escudoSnorlax1.Value == 30)
            {
                dtReloj.Stop();
                comprobarDebilitado();
            }
        }

        private void UsarDobleFilo(object sender, object e)
        {

            comprobarDebilitado();

            if (debilitado == false)
            {
                Storyboard dobleFilo = (Storyboard)this.Resources["dobleFilo"];
                dobleFilo.Begin();
                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj.Tick += bajarVida;
                dtReloj.Start();
                turno += 1;
                comprobarTurnoAsync(turno);
            }
        }

        private void bajarVida(object sender, object e)
        {
            PB_corazon1.Value -= 1.0;
            PB_corazonSnorlax.Value -= 1.0;
            if (PB_corazon1.Value == 40 || PB_corazonSnorlax.Value == 40)
            {
                dtReloj.Stop();
                comprobarDebilitado();
            }

        }

        private void UsarAleatorio(object sender, object e)
        {

            comprobarDebilitado();
            if (debilitado == false)
            {
                var seed = Environment.TickCount;
                var random = new Random(seed);
                var value = random.Next(0, 3);
                if (value == 0)
                {
                    Storyboard Grunido = (Storyboard)this.Resources["Grunido"];
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
                else if (value == 1)
                {
                    Storyboard dobleFilo = (Storyboard)this.Resources["dobleFilo"];
                    dobleFilo.Begin();
                    dtReloj = new DispatcherTimer();
                    dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                    dtReloj.Tick += bajarVida;
                    dtReloj.Start();
                }
                else if (value == 2)
                {
                    Storyboard Encanto = (Storyboard)this.Resources["Encanto"];
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
                turno += 1;
                comprobarTurnoAsync(turno);
            }
        }


        //ATAQUES SNORLAX1
        private void UsarPocima(object sender, object e)
        {

            comprobarDebilitado();
            if (debilitado == false)
            {
                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj.Tick += subirVidaSnorlax1;
                dtReloj.Start();
                Img_pocima.Opacity = 0.5;
                turno += 1;
                comprobarTurnoAsync(turno);
            }
        }

        private void subirVidaSnorlax1(object sender, object e)
        {
            PB_corazon1.Value += 1;
            if (PB_corazon1.Value == 100)
            {
                dtReloj.Stop();
                Img_pocima.Opacity = 0.5;
                comprobarDebilitado();
            }
        }

        private void golpeCuerpo(object sender, object e)
        {

            comprobarDebilitado();
            if (debilitado == false)
            {
                Storyboard golpeCuerpo = (Storyboard)this.Resources["golpeCuerpo"];
                golpeCuerpo.Begin();
                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj.Tick += bajarVidaSnorlax1;
                dtReloj.Start();
                turno += 1;
                comprobarTurnoAsync(turno);
            }
        }

        private void bajarVidaSnorlax1(object sender, object e)
        {
            PB_corazon.Value -= 1;
            PB_corazonSnorlax.Value -= 1.0;
            if (PB_corazon.Value <= 20 || PB_corazonSnorlax.Value <= 20)
            {
                dtReloj.Stop();
                comprobarDebilitado();
            }

        }

        private void placaje(object sender, object e)
        {

            comprobarDebilitado();
            if (debilitado == false)
            {
                Storyboard Placaje = (Storyboard)this.Resources["Placaje"];
                Placaje.Begin();
                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj.Tick += bajarEscudoSnorlax1;
                dtReloj.Start();
                turno += 1;
                comprobarTurnoAsync(turno);
            }
        }

        private void bajarEscudoSnorlax1(object sender, object e)
        {
            PB_escudo.Value -= 1;
            PB_escudoSnorlaz2.Value -= 1.0;
            if (PB_escudo.Value == 20 || PB_escudoSnorlaz2.Value == 20)
            {
                dtReloj.Stop();
                comprobarDebilitado();
            }
        }

        private void golpeCabeza(object sender, object e)
        {

            comprobarDebilitado();
            if (debilitado == false)
            {
                Storyboard golpeCabeza = (Storyboard)this.Resources["golpeCabeza"];
                golpeCabeza.Begin();
                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj.Tick += subirEscudoSnorlax1;
                dtReloj.Start();
                turno += 1;
                comprobarTurnoAsync(turno);
            }
        }

        private void subirEscudoSnorlax1(object sender, object e)
        {
            PB_escudoSnorlax1.Value += 1.0;
            if (PB_escudoSnorlax1.Value == 80)
            {
                dtReloj.Stop();
                comprobarDebilitado();
            }
        }

        private void UsarAleatorioSnorlax1(object sender, object e)
        {

            comprobarDebilitado();
            if (debilitado == false)
            {
                var seed = Environment.TickCount;
                var random = new Random(seed);
                var value = random.Next(0, 3);
                if (value == 0)
                {
                    Storyboard golpeCabeza = (Storyboard)this.Resources["golpeCabeza"];
                    golpeCabeza.Begin();
                    dtReloj = new DispatcherTimer();
                    dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                    dtReloj.Tick += subirEscudoSnorlax1;
                    dtReloj.Start();
                }
                else if (value == 1)
                {
                    Storyboard Placaje = (Storyboard)this.Resources["Placaje"];
                    Placaje.Begin();
                    dtReloj = new DispatcherTimer();
                    dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                    dtReloj.Tick += bajarEscudoSnorlax1;
                    dtReloj.Start();
                }
                else if (value == 2)
                {
                    Storyboard golpeCuerpo = (Storyboard)this.Resources["golpeCuerpo"];
                    golpeCuerpo.Begin();
                    dtReloj = new DispatcherTimer();
                    dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                    dtReloj.Tick += bajarVidaSnorlax1;
                    dtReloj.Start();
                }
                turno += 1;
                comprobarTurnoAsync(turno);
            }
        }


        //ATAQUES SNORLAX2

        private void usarPocimaSnorlax2(object sender, TappedRoutedEventArgs e)
        {

            comprobarDebilitado();
            if (debilitado == false)
            {
                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj.Tick += subirVidaSnorlax2;
                dtReloj.Start();
                Img_pocima.Opacity = 0.5;
                turno += 1;
                comprobarTurnoAsync(turno);
            }
        }

        private void subirVidaSnorlax2(object sender, object e)
        {
            PB_corazonSnorlax.Value += 1.0;
            if (PB_corazonSnorlax.Value == 100)
            {
                dtReloj.Stop();
                comprobarDebilitado();
            }
        }

        private void ataqueDescanso(object sender, RoutedEventArgs e)
        {

            comprobarDebilitado();
            if (debilitado == false)
            {
                btnTambor.Visibility = Visibility.Collapsed;
                Storyboard sb = (Storyboard)this.Resources["sbDescanso"];
                tbConsola.Text = "¡ SNORLAX usó DESCANSO ! ";
                imZzZ.Width = 40; imZzZ.Height = 40; imZzZ.Visibility = Visibility.Visible;
                sb.Begin();

                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj.Tick += bajarEscudoSnorlax2;
                dtReloj.Start();
                turno += 1;
                comprobarTurnoAsync(turno);
            }
        }

        private void bajarEscudoSnorlax2(object sender, object e)
        {
            PB_escudo.Value -= 1.0;
            PB_escudoSnorlax1.Value -= 1.0;
            if (PB_escudo.Value == 30 || PB_escudoSnorlax1.Value == 30)
            {
                dtReloj.Stop();
                comprobarDebilitado();
            }
        }

        private void ataqueRizoDefensa(object sender, RoutedEventArgs e)
        {
            comprobarDebilitado();
            if (debilitado == false)
            {
                Storyboard sb = (Storyboard)this.Resources["sbDefensa"];
                tbConsola.Text = "¡ SNORLAX usó RIZO DEFENSA ! ";
                ellips.Visibility = Visibility.Visible;
                ellipse2.Visibility = Visibility.Visible;
                sb.Begin();
                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj.Tick += subirEscudoSnorlax2;
                dtReloj.Start();
                turno += 1;
                comprobarTurnoAsync(turno);
            }
        }

        private void subirEscudoSnorlax2(object sender, object e)
        {
            PB_escudoSnorlaz2.Value += 1.0;
            if (PB_escudoSnorlaz2.Value == 80)
            {
                dtReloj.Stop();
                comprobarDebilitado();
            }
        }

        private void ataqueGolpeCuerpo(object sender, object e)
        {

            comprobarDebilitado();
            if (debilitado == false)
            {
                tbConsola.Text = "¡ SNORLAX usó AYUDA ! ";
                var seed = Environment.TickCount;
                var random = new Random(seed);
                var value = random.Next(0, 3);

                if (value == 0)
                {
                    Storyboard sb = (Storyboard)this.Resources["sbDescanso"];
                    tbConsola.Text = "¡ SNORLAX usó DESCANSO ! ";
                    imZzZ.Width = 40; imZzZ.Height = 40; imZzZ.Visibility = Visibility.Visible;
                    sb.Begin();
                    dtReloj = new DispatcherTimer();
                    dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                    dtReloj.Tick += bajarEscudoSnorlax2;
                    dtReloj.Start();
                    if (PB_corazonSnorlax.Value >= 100)
                    {
                        this.pocimaSnorlax2.Opacity = 0.0;
                    }

                }
                else if (value == 1)
                {
                    Storyboard sb = (Storyboard)this.Resources["sbDefensa"];
                    tbConsola.Text = "¡ SNORLAX usó RIZO DEFENSA ! ";
                    ellips.Visibility = Visibility.Visible;
                    ellipse2.Visibility = Visibility.Visible;
                    sb.Begin();
                    dtReloj = new DispatcherTimer();
                    dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                    dtReloj.Tick += subirEscudoSnorlax2;
                    dtReloj.Start();
                }
                else
                {
                    tbConsola.Text = "¡ SNORLAX usó TAMBOR ! ";
                    path.Visibility = Visibility.Visible;
                    image.Visibility = Visibility.Visible;
                    image_Copy.Visibility = Visibility.Visible;
                    image1.Visibility = Visibility.Visible;
                    image1_Copy1.Visibility = Visibility.Visible;
                    image2.Visibility = Visibility.Visible;

                    dtReloj = new DispatcherTimer();
                    dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                    dtReloj.Tick += bajarVidaSnorlax2;
                    dtReloj.Start();
                    if (PB_corazonSnorlax.Value < 1)
                    {
                        consolaKO();
                    }
                    else
                    {
                        Storyboard sb = (Storyboard)this.Resources["sbTambor"];
                        sb.Begin();
                    }
                    if (PB_corazonSnorlax.Value <= 100)
                    {
                        this.pocimaSnorlax2.Opacity = 100;
                    }
                }
                turno += 1;
                comprobarTurnoAsync(turno);
            }
        }

        private void ataqueTambor(object sender, RoutedEventArgs e)
        {

            comprobarDebilitado();
            if (debilitado == false)
            {
                tbConsola.Text = "¡ SNORLAX usó TAMBOR ! ";
                path.Visibility = Visibility.Visible;
                image.Visibility = Visibility.Visible;
                image_Copy.Visibility = Visibility.Visible;
                image1.Visibility = Visibility.Visible;
                image1_Copy1.Visibility = Visibility.Visible;
                image2.Visibility = Visibility.Visible;

                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj.Tick += bajarVidaSnorlax2;
                dtReloj.Start();
                if (PB_corazonSnorlax.Value < 1)
                {
                    consolaKO();
                }
                else
                {
                    Storyboard sb = (Storyboard)this.Resources["sbTambor"];
                    sb.Begin();
                }
                turno += 1;
                comprobarTurnoAsync(turno);
            }
        }

        private void bajarVidaSnorlax2(object sender, object e)
        {
            PB_corazon1.Value -= 1.0;
            PB_corazon.Value -= 1.0;
            if (PB_corazon1.Value == 40 || PB_corazon.Value == 40)
            {
                dtReloj.Stop();
                comprobarDebilitado(); 
            }
        }

        private void consolaKO()
        {
            Storyboard sb = (Storyboard)this.Resources["sbKO"];
            tbConsola.Text = "¡ SNORLAX se debilitó ! ";
            sb.Begin();
            this.pocimaSnorlax2.Opacity = 0.0;
        }

        private void ayuda_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imagenAyuda.Visibility = Visibility.Visible;
            if (numero == 0)
            {
                imagenAyuda.Source = new BitmapImage(new Uri("ms-appx:///Assets/ventanaAyudaEsp.png"));
            } else if (numero == 1)
            {
                imagenAyuda.Source = new BitmapImage(new Uri("ms-appx:///Assets/ventanaAyudaIng.png"));
            } else if (numero == 2)
            {
                imagenAyuda.Source = new BitmapImage(new Uri("ms-appx:///Assets/ventanaAyudaAle.png"));
            }
        }

        private void Emergente_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imagenAyuda.Visibility = Visibility.Collapsed;
        }
    }


}