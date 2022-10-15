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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using System.Linq;
using System.Collections.ObjectModel;
using CommunityToolkit.WinUI.Notifications;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PokedexPage : Page
    {
        List<Pokemon> nombres;
        Boolean bandera = false;
        Boolean banderaCharizard = false;
        Boolean banderaGolbat = false;
        Boolean banderaDodrio = false;
        Boolean banderaSnorlaxM = false;
        Boolean banderaSnorlaxH = false;       
        Boolean banderaZapdos = false;
        Boolean banderaDragonite = false;
        Boolean banderaTogepi = false;
        Boolean banderaAipom = false;
        Boolean banderaCastform = false;

        public class Pokemon
        {
            public string nombre { get; set; }
            public int numero { get; set; }
            public string imagen { get; set; }

        }

        public string titulo = "";
        public string texto = "";

        public PokedexPage()
        {
            this.InitializeComponent();
            int numero = MainPage.index;
            


            if (numero == 0)
            {
                lblMisPokemons.Text = "Mis Pokemons";
                btnPokedex.Content = "Ver en Pokedex";
                titulo = "¡POKEMON FAVORITO!";
                texto = "Este pokemon ha sido marcado como uno de tus pokemons favoritos.";
                sbar.PlaceholderText = "Buscar Pokemon... (primera letra en mayúscula)";
            }
            else if (numero == 1)
            {
                lblMisPokemons.Text = "My Pokemons";
                btnPokedex.Content = "See in Pokedex";
                titulo = "FAVOURITE POKEMON!";
                texto = "This pokemon has been marked as one of your favorite pokemons.";
                sbar.PlaceholderText = "Find Pokemon... (first letter capitalized)";
            }
            else if (numero == 2)
            {
                lblMisPokemons.Text = "Mein Pokémons";
                btnPokedex.Content = "Siehe Pokedex";
                titulo = "LIEBLINGS-POKÉMON!";
                texto = "Dieses Pokémon wurde als eines Ihrer Lieblingspokemons markiert.";
                sbar.PlaceholderText = "Pokémon finden... (erster Buchstabe groß)";
            }

            nombres = new List<Pokemon>();
            nombres.Add(new Pokemon() { nombre = "Charizard", numero = 006, imagen = "/Assets/pokeballAzul.png" });
            nombres.Add(new Pokemon() { nombre = "Golbat", numero = 042, imagen = "/Assets/RapidBall.png" });
            nombres.Add(new Pokemon() { nombre = "Dodrio", numero = 085, imagen = "/Assets/pokeballVerde.png" });           
            nombres.Add(new Pokemon() { nombre = "SnorlaxM", numero = 143, imagen = "/Assets/Pokebola-pokeball-png-0.scale-200.png" });
            nombres.Add(new Pokemon() { nombre = "SnorlaxH", numero = 143, imagen = "/Assets/MasterBall.png" });
            nombres.Add(new Pokemon() { nombre = "Zapdos", numero = 145, imagen = "/Assets/pokeballAzul.png" });
            nombres.Add(new Pokemon() { nombre = "Dragonite", numero = 149, imagen = "/Assets/HealBall.png" });
            nombres.Add(new Pokemon() { nombre = "Togepi", numero = 175, imagen = "/Assets/PremierBall.png" });
            nombres.Add(new Pokemon() { nombre = "Aipom", numero = 190, imagen = "/Assets/gsBall.png" });
            nombres.Add(new Pokemon() { nombre = "Castform", numero = 351, imagen = "/Assets/RapidBall.png" });
            mylst.ItemsSource = nombres;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var pokemonBusc1 = from s in nombres where s.nombre.Contains(sbar.Text) select s;
            mylst.ItemsSource = pokemonBusc1;
            bandera = true;           
        }

        private void sbar_TextChanged(object sender, TextChangedEventArgs e)
        {
            mylst.ItemsSource = nombres;
            bandera = false;
        }

        private void PokeTogepi_Tapped(object sender, TappedRoutedEventArgs e)
        {
            nombrePokemon.Text = "Togepi";
            PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/togepi.png"));
        }

        private void btnPokedex_Click(object sender, RoutedEventArgs e)
        {         
            if (nombrePokemon.Text == "Charizard")
            {
                ImagenAmpliar.Visibility = Visibility.Collapsed;
                ImagenReducir.Visibility = Visibility.Collapsed;
                fmPokedex.Navigate(typeof(PokedexCharizard));
            }
            else if (nombrePokemon.Text == "Golbat")
            {
                ImagenAmpliar.Visibility = Visibility.Collapsed;
                ImagenReducir.Visibility = Visibility.Collapsed;
                fmPokedex.Navigate(typeof(PokedexGolbat));
            }
            else if (nombrePokemon.Text == "Dodrio")
            {
                ImagenAmpliar.Visibility = Visibility.Collapsed;
                ImagenReducir.Visibility = Visibility.Collapsed;
                fmPokedex.Navigate(typeof(PokedexDodrio));
            }
            else if (nombrePokemon.Text == "SnorlaxM")
            {
                ImagenAmpliar.Visibility = Visibility.Collapsed;
                ImagenReducir.Visibility = Visibility.Collapsed;
                fmPokedex.Navigate(typeof(PokedexSnorlax));
            }
            else if (nombrePokemon.Text == "SnorlaxH")
            {
                ImagenAmpliar.Visibility = Visibility.Collapsed;
                ImagenReducir.Visibility = Visibility.Collapsed;
                fmPokedex.Navigate(typeof(PokedexSnorlax));
            }
            else if (nombrePokemon.Text == "Zapdos")
            {
                ImagenAmpliar.Visibility = Visibility.Collapsed;
                ImagenReducir.Visibility = Visibility.Collapsed;
                fmPokedex.Navigate(typeof(PokedexZapdos));
            }
            else if (nombrePokemon.Text == "Dragonite")
            {
                ImagenAmpliar.Visibility = Visibility.Collapsed;
                ImagenReducir.Visibility = Visibility.Collapsed;
                fmPokedex.Navigate(typeof(PokedexDragonite));
            }
            else if (nombrePokemon.Text == "Togepi")
            {
                ImagenAmpliar.Visibility = Visibility.Collapsed;
                ImagenReducir.Visibility = Visibility.Collapsed;
                fmPokedex.Navigate(typeof(PokedexTogepi));
            }
            else if (nombrePokemon.Text == "Aipom")
            {
                ImagenAmpliar.Visibility = Visibility.Collapsed;
                ImagenReducir.Visibility = Visibility.Collapsed;
                fmPokedex.Navigate(typeof(PokedexAipom));
            }
            else if (nombrePokemon.Text == "Castform")
            {
                ImagenAmpliar.Visibility = Visibility.Collapsed;
                ImagenReducir.Visibility = Visibility.Collapsed;
                fmPokedex.Navigate(typeof(PokedexCastform));
            }
        }

        private void PokeSnorlax1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            nombrePokemon.Text = "Snorlax";
            PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Snorlax1.png"));
        }

        private void PokeSnorlax2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            nombrePokemon.Text = "Snorlax";
            PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Snorlax2.png"));
        }


        private void ImagenAmpliar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if(nombrePokemon.FontSize < 50)
            {
                nombrePokemon.FontSize++;
                lblMisPokemons.FontSize++;
                btnPokedex.FontSize++;
            }

            if (tituloPokedex.FontSize < 70)
            {
                tituloPokedex.FontSize++;
            }
        }

        private void ImagenReducir_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (nombrePokemon.FontSize > 30)
            {
                nombrePokemon.FontSize--;
                lblMisPokemons.FontSize--;
                btnPokedex.FontSize--;
            }

            if (tituloPokedex.FontSize > 45)
            {
                tituloPokedex.FontSize--;
            }

        }

        private void PokeAipom_Tapped(object sender, TappedRoutedEventArgs e)
        {
            nombrePokemon.Text = "Aipom";
            PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Aipom.png"));
        }

        private void PokeCastform_Tapped(object sender, TappedRoutedEventArgs e)
        {
            nombrePokemon.Text = "Castform";
            PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/castform.png"));
        }

        private void PokeCharizard_Tapped(object sender, TappedRoutedEventArgs e)
        {
            nombrePokemon.Text = "Charizard";
            PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Charizard.png"));
        }

        private void PokeDodrio_Tapped(object sender, TappedRoutedEventArgs e)
        {
            nombrePokemon.Text = "Dodrio";
            PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dodrio.png"));
        }

        private void PokeDragonite_Tapped(object sender, TappedRoutedEventArgs e)
        {
            nombrePokemon.Text = "Dragonite";
            PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dragonite.png"));
        }

        private void PokeGolbat_Tapped(object sender, TappedRoutedEventArgs e)
        {
            nombrePokemon.Text = "Golbat";
            PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Golbat.png"));
        }

        private void PokeZapdos_Tapped(object sender, TappedRoutedEventArgs e)
        {
            nombrePokemon.Text = "Zapdos";
            PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/zapdos.png"));
        }

        private void mylst_Tapped(object sender, object e)
        {
            var pokemonBusc2 = from s in nombres where s.nombre.Contains(sbar.Text) select s.nombre;
            
            if (bandera == false) {
                if (mylst.SelectedIndex == 0)
                {
                    nombrePokemon.Text = "Charizard";
                    PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Charizard.png"));
                    if(banderaCharizard == false)
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    }
                    else
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    }
                }
                else if (mylst.SelectedIndex == 1)
                {
                    nombrePokemon.Text = "Golbat";
                    PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Golbat.png"));
                    if (banderaGolbat == false)
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    }
                    else
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    }
                }
                else if (mylst.SelectedIndex == 2)
                {
                    nombrePokemon.Text = "Dodrio";
                    PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dodrio.png"));
                    if (banderaDodrio == false)
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    }
                    else
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    }
                }
                else if (mylst.SelectedIndex == 3)
                {
                    nombrePokemon.Text = "SnorlaxM";
                    PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/SnorlaxM.png"));
                    if (banderaSnorlaxM == false)
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    }
                    else
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    }
                }
                else if (mylst.SelectedIndex == 4)
                {
                    nombrePokemon.Text = "SnorlaxH";
                    PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/SnorlaxH.png"));
                    if (banderaSnorlaxH == false)
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    }
                    else
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    }
                }
                else if (mylst.SelectedIndex == 5)
                {
                    nombrePokemon.Text = "Zapdos";
                    PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Zapdos.png"));
                    if (banderaZapdos == false)
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    }
                    else
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    }
                }
                else if (mylst.SelectedIndex == 6)
                {
                    nombrePokemon.Text = "Dragonite";
                    PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dragonite.png"));
                    if (banderaDragonite == false)
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    }
                    else
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    }
                }
                else if (mylst.SelectedIndex == 7)
                {
                    nombrePokemon.Text = "Togepi";
                    PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Togepi.png"));
                    if (banderaTogepi == false)
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    }
                    else
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    }
                }
                else if (mylst.SelectedIndex == 8)
                {
                    nombrePokemon.Text = "Aipom";
                    PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Aipom.png"));
                    if (banderaAipom == false)
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    }
                    else
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    }
                }
                else if (mylst.SelectedIndex == 9)
                {
                    nombrePokemon.Text = "Castform";
                    PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Castform.png"));
                    if (banderaCastform == false)
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    }
                    else
                    {
                        imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    }
                }
            }
            else
            {
                string[] pokemonsBuscados = pokemonBusc2.ToArray();
                
                if (pokemonsBuscados.Length > 1)
                {
                    if (mylst.SelectedIndex == 0)
                    {
                        nombrePokemon.Text = pokemonsBuscados[0];
                        PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + nombrePokemon.Text + ".png"));
                    } else if (mylst.SelectedIndex == 1)
                    {
                        nombrePokemon.Text = pokemonsBuscados[1];
                        PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + nombrePokemon.Text + ".png"));
                    }

                } else
                {
                    nombrePokemon.Text = pokemonsBuscados[0];
                    PokeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + nombrePokemon.Text + ".png"));
                }

                
            }
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
            if (nombrePokemon.Text == "Charizard")
            {
                if(banderaCharizard == false)
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    banderaCharizard = true;
                    notificarFavorito("Charizard");
                }
                else
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    banderaCharizard = false;
                }            
            }
            else if (nombrePokemon.Text == "Golbat")
            {
                if (banderaGolbat == false)
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    banderaGolbat = true;
                    notificarFavorito("Golbat");
                }
                else
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    banderaGolbat = false;
                }
            }
            else if (nombrePokemon.Text == "Dodrio")
            {
                if (banderaDodrio == false)
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    banderaDodrio = true;
                    notificarFavorito("Dodrio");
                }
                else
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    banderaDodrio = false;
                }
            }
            else if (nombrePokemon.Text == "SnorlaxM")
            {
                if (banderaSnorlaxM == false)
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    banderaSnorlaxM = true;
                    notificarFavorito("SnorlaxM");
                }
                else
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    banderaSnorlaxM = false;
                }
            }
            else if (nombrePokemon.Text == "SnorlaxH")
            {
                if (banderaSnorlaxH == false)
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    banderaSnorlaxH = true;
                    notificarFavorito("SnorlaxH");
                }
                else
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    banderaSnorlaxH = false;
                }
            }
            else if (nombrePokemon.Text == "Zapdos")
            {
                if (banderaZapdos == false)
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    banderaZapdos = true;
                    notificarFavorito("Zapdos");
                }
                else
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    banderaZapdos = false;
                }
            }
            else if (nombrePokemon.Text == "Dragonite")
            {
                if (banderaDragonite == false)
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    banderaDragonite = true;
                    notificarFavorito("Dragonite");
                }
                else
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    banderaDragonite = false;
                }
            }
            else if (nombrePokemon.Text == "Togepi")
            {
                if (banderaTogepi == false)
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    banderaTogepi = true;
                    notificarFavorito("Togepi");
                }
                else
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    banderaTogepi = false;
                }
            }
            else if (nombrePokemon.Text == "Aipom")
            {
                if (banderaAipom == false)
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    banderaAipom = true;
                    notificarFavorito("Aipom");
                }
                else
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    banderaAipom = false;
                }
            }
            else if (nombrePokemon.Text == "Castform")
            {
                if (banderaCastform == false)
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrella.png"));
                    banderaCastform = true;
                    notificarFavorito("Castform");
                }
                else
                {
                    imgFavorito.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellaVacia.png"));
                    banderaCastform = false;
                }
            }
        }

        
        private void notificarFavorito(string nombrePokemon)
        {
            new ToastContentBuilder()
            .AddArgument("action", "favoritos")
            .AddArgument("conversationId", 9813)
            .AddText(titulo)
            .AddText(texto)
            .AddAppLogoOverride(new Uri("ms-appx:///Assets/estrella.png"), ToastGenericAppLogoCrop.Circle)
            .Show();

        }

    }
}
