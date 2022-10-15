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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CombatePage : Page
    {
        public CombatePage()
        {
            this.InitializeComponent();
            int numero = MainPage.index;

            
            if (numero == 0)
            {
                lblCombate.Text = "Combate";
                lblMiPokemon.Text = "Mío";
                lblModoJuego.Text = "Seleccione el número de jugadores:";
                lblOponente.Text = "Oponente";
                lblPokemons.Text = "Seleccione los pokemons para el combate:";
                btnCombatir.Content = "Combatir";
                lblAdvertencia.Text = "¡El pokemon oponente no puede ser el mismo que el pokemon propio!";
            }
            else if (numero == 1)
            {
                lblCombate.Text = "Combat";
                lblMiPokemon.Text = "Mine";
                lblModoJuego.Text = "Select the number of players:";
                lblOponente.Text = "Opponent";
                lblPokemons.Text = "Select the pokemons for battle:";
                btnCombatir.Content = "Fight";
                lblAdvertencia.Text = "The opposing pokemon cannot be the same as your own pokemon!";
            }
            else if (numero == 2)
            {
                lblCombate.Text = "Kampf";
                lblMiPokemon.Text = "Mein";
                lblModoJuego.Text = "Wählen Sie die Anzahl der Spieler:";
                lblOponente.Text = "Gegner";
                lblPokemons.Text = "Wähle die Pokémon für den Kampf aus:";
                btnCombatir.Content = "Kampf";
                lblAdvertencia.Text = "Das gegnerische Pokémon kann nicht dasselbe sein wie dein eigenes Pokémon!";
            }
        }

        private void ImagenAmpliar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (lblCombate.FontSize < 74)
            {
                lblCombate.FontSize++;
            }

            if (lblModoJuego.FontSize < 37)
            {
                lblModoJuego.FontSize++;
                lblMiPokemon.FontSize++;
                lblOponente.FontSize++;
                lblPokemons.FontSize++;
                n1.FontSize++;
                n2.FontSize++;
                n3.FontSize++;
            }
            if (cbModoJuego.FontSize < 28)
            {
                cbModoJuego.FontSize++;
                cbMiPokemon.FontSize++;
                cbOponente.FontSize++;
            }
        }

        

        private void ImagenReducir_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            
            if (lblCombate.FontSize > 66)
            {
                lblCombate.FontSize--;
            }

            if (lblModoJuego.FontSize > 30)
            {
                lblModoJuego.FontSize--;
                lblMiPokemon.FontSize--;
                lblOponente.FontSize--;
                lblPokemons.FontSize--;
                n1.FontSize--;
                n2.FontSize--;
                n3.FontSize--;
            }
            if (cbModoJuego.FontSize > 24)
            {
                cbModoJuego.FontSize--;
                cbMiPokemon.FontSize--;
                cbOponente.FontSize--;
            }
        }

        public static int pokemon1 = 0;
        public static int pokemon2 = 0;


        private void cbModoJuego_Tapped(object sender, TappedRoutedEventArgs e)
        {
            cbMiPokemon.IsEnabled = true;
        }


        private void cbMiPokemon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbMiPokemon.SelectedIndex == 0)
            {
                pokemon1 = 0;
            }
            else if (cbMiPokemon.SelectedIndex == 1)
            {
                pokemon1 = 1;
            }
            else if (cbMiPokemon.SelectedIndex == 2)
            {
                pokemon1 = 2;
            }
            cbOponente.IsEnabled = true;
            mismoPokemon();
        }

        private void mismoPokemon()
        {
            if (cbMiPokemon.SelectedIndex == cbOponente.SelectedIndex)
            {
                lblAdvertencia.Visibility = Visibility.Visible;
                btnCombatir.IsEnabled = false;
            } else
            {
                lblAdvertencia.Visibility = Visibility.Collapsed;
                btnCombatir.IsEnabled = true;
            }
        }


        private void cbOponente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbOponente.SelectedIndex == 0)
            {
                pokemon2 = 0;
            }
            else if (cbOponente.SelectedIndex == 1)
            {
                pokemon2 = 1;
            }
            else if (cbOponente.SelectedIndex == 2)
            {
                pokemon2 = 2;
            }
            mismoPokemon();

            
        }


        private void combatir_Click(object sender, RoutedEventArgs e)
        {
            if (cbModoJuego.SelectedIndex == 0)
            {
                fmCombate.Navigate(typeof(Combate1Jug));
                fmCombate.Navigate(typeof(Combate1Jug), pokemon1);
                fmCombate.Navigate(typeof(Combate1Jug), pokemon2);
            }
            else if (cbModoJuego.SelectedIndex == 1)
            {
                fmCombate.Navigate(typeof(Combate2Jug));
                fmCombate.Navigate(typeof(Combate2Jug), pokemon1);
                fmCombate.Navigate(typeof(Combate2Jug), pokemon2);
            }
        }

        
    }
}
