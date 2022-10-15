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
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace App1
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>

    public sealed partial class MainPage : Page
    {
        public static int index = 0;
        public MainPage()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize
           (new Size(320, 320));
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged
           += MainPage_VisibleBoundsChanged;
            

        }

        private void comboBoxIdioma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (comboBoxIdioma.SelectedIndex == 0)
            {
                index = 0;
                btnInicio.Content = "Inicio";
                btnCombate.Content = "Combate";
            }
            else if (comboBoxIdioma.SelectedIndex == 1)
            {
                index = 1;
                btnInicio.Content = "Home";
                btnCombate.Content = "Combat";
            }
            else if (comboBoxIdioma.SelectedIndex == 2)
            {
                index = 2;
                btnInicio.Content = "Start";
                btnCombate.Content = "Kampf";
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sView.IsPaneOpen = !sView.IsPaneOpen;            
        }

        private void MainPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if (Width <= 600)
            {
                sView.DisplayMode = SplitViewDisplayMode.Overlay;
            }
            else
            {
                sView.DisplayMode = SplitViewDisplayMode.CompactInline;
            }
        }



        private void IrInicio(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(InicioPage));
            comboBoxIdioma.Visibility = Visibility.Visible;
            ImagenAmpliar.Visibility = Visibility.Visible;
            ImagenReducir.Visibility = Visibility.Visible;
        }

        private void irCombatePage(object sender, RoutedEventArgs e)
        {
            ImagenAmpliar.Visibility = Visibility.Collapsed;
            ImagenReducir.Visibility = Visibility.Collapsed;
            fmMain.Navigate(typeof(CombatePage));
            comboBoxIdioma.Visibility = Visibility.Collapsed;
        }

        private void irPokedexPage(object sender, RoutedEventArgs e)
        {
            ImagenAmpliar.Visibility = Visibility.Collapsed;
            ImagenReducir.Visibility = Visibility.Collapsed;
            fmMain.Navigate(typeof(PokedexPage));
            fmMain.Navigate(typeof(PokedexPage), index);
            comboBoxIdioma.Visibility = Visibility.Collapsed;
        }

        private void ImagenAmpliar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (btnInicio.FontSize<32)
            { 
                btnInicio.FontSize++;
                btnPokedex.FontSize++;
                btnCombate.FontSize++;
            }
            if (btnCombate.FontSize < 28)
            {
                comboBoxIdioma.FontSize++;
            }
        }

        private void ImagenReducir_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (btnInicio.FontSize > 18)
            {
                btnInicio.FontSize--;
                btnPokedex.FontSize--;
                btnCombate.FontSize--;
            }
            if (btnCombate.FontSize > 24)
            {
                comboBoxIdioma.FontSize--;
            }
        }
    }


}
