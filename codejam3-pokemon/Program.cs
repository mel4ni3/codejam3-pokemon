using PokeAPI;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Windows;
using Windows.UI.Xaml.Media.Imaging;
using System.Drawing;

class Program
{
    public static async Task Main(string[] args)
    {
        
        string title = @"
                                  ,'\
    _.----.        ____         ,'  _\   ___    ___     ____
_,-'       `.     |    |  /`.   \,-'    |   \  /   |   |    \  |`.
\      __    \    '-.  | /   `.  ___    |    \/    |   '-.   \ |  |
 \.    \ \   |  __  |  |/    ,','_  `.  |          | __  |    \|  |
   \    \/   /,' _`.|      ,' / / / /   |          ,' _`.|     |  |
    \     ,-'/  /   \    ,'   | \/ / ,`.|         /  /   \  |     |
     \    \ |   \_/  |   `-.  \    `'  /|  |    ||   \_/  | |\    |
      \    \ \      /       `-.`.___,-' |  |\  /| \      /  | |   |
       \    \ `.__,'|  |`-._    `|      |__| \/ |  `.__,'|  | |   |
        \_.-'       |__|    `-._ |              '-.|     '-.| |   |
                                `'                            '-._|                                                                                       
                                                                           ";

        Console.WriteLine(title);

        Console.WriteLine("Welcome to the Pokedex!");

        //Console.WriteLine("Enter the name of a Pokemon to see its stats!");

        //var p = Console.ReadLine();

        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("Enter the name of a Pokemon to see its stats! Enter quit to quit.");
            var p = Console.ReadLine()?.ToLower();

            if (p == "quit")
            {
                quit = true;
                break;
            }
            else
            {
            // Console.WriteLine("Pick a number to the see the stats:");


                await GetPokemon(p.ToLower());
                await GetFemaletoMaleRate(p);
                await GetBaseHappiness(p);
            }
        } 
        }

    public static async Task GetFemaletoMaleRate(string pokemonspecies){
        PokemonSpecies p = await DataFetcher.GetNamedApiObject<PokemonSpecies>(pokemonspecies);

        float? r = p.FemaleToMaleRate;

        Console.WriteLine(p.Name + " has a female to male rate of " + r + "!");
    }

    public static async Task GetBaseHappiness(string pokemonspecies){
        PokemonSpecies p = await DataFetcher.GetNamedApiObject<PokemonSpecies>(pokemonspecies);

        int r = p.BaseHappiness;

        Console.WriteLine(p.Name + " has a base happiness of " + r + "!");
    }
    
    public static async Task GetPokemon(string pokemonspecies)
    {

        //Console.WriteLine("hi");

        //PokemonSpecies p = await DataFetcher.GetApiObject<PokemonSpecies>(395);

        try
        {
            PokemonSpecies p = await DataFetcher.GetNamedApiObject<PokemonSpecies>(pokemonspecies);
            if (pokemonspecies == "jigglypuff")
            {

                Console.ForegroundColor = ConsoleColor.Magenta;
                string jigglypuff = @"
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣴⠶⠛⠉⠹⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣤⣤⣤⣀⣤⠞⠋⠀⢀⣴⣿⣇⠹⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⠾⠛⠉⠁⠀⠈⠉⠙⠳⣦⣤⣿⣿⣿⣿⡄⢿⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⣿⡇⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀
⢀⣶⠶⠶⠶⠶⠶⢶⣦⣤⣤⣤⣶⠾⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⣿⣿⣧⠈⣇⠀⠀⠀⠀⠀⠀⠀⠀
⣼⡇⠀⣰⣶⣤⣤⣤⣤⣄⣈⣉⠙⠒⡷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠛⢿⣀⣿⠀⠀⠀⠀⠀⠀⠀⠀
⢿⡇⠀⢹⣿⣿⣿⣿⣿⣿⣿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠙⢿⣄⠀⠀⠀⠀⠀⠀⠀
⢸⡇⠀⠸⣿⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠲⢦⣤⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠙⢧⡀⠀⠀⠀⠀⠀
⢸⣇⠀⠀⢻⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡟⠙⢷⡄⠀⠀⠀⠀⠀⢀⣿⣶⣿⡿⢷⣄⠈⢿⡄⠀⠀⠀⠀
⠈⣿⠀⠀⠈⢿⣿⣿⠃⠀⠀⠀⠀⣀⣀⣤⣤⣀⡀⠀⣧⠀⠀⠀⠀⠀⠀⠀⢠⡾⢿⣿⣿⡀⠀⢹⣧⠀⢻⡀⠀⠀⠀
⠀⠹⣧⠀⠀⠈⢿⡏⠀⠀⢀⡴⠋⣩⣿⣿⡿⠛⠻⣷⣼⡷⣄⣀⣀⣠⣤⠾⠋⠀⣾⣿⣿⣿⣶⣾⣿⣇⠈⣧⠀⠀⠀
⠀⠀⣿⡆⠀⠀⠀⠀⠀⢠⡟⢠⣾⣿⣿⣟⠀⠀⠀⢸⣿⣷⡀⠉⠉⠁⠀⠀⠀⠀⢻⣿⣿⣿⣿⣿⣿⣿⠀⢿⠟⠛⣷
⠀⠀⣿⠀⠀⠀⠀⠀⠀⣿⠀⣾⣿⣿⣿⣿⣦⣀⣠⣾⣿⡏⢷⠀⠀⠀⠀⠀⠀⠀⠘⣎⠻⣿⣿⣿⣿⣿⠀⢸⠀⣸⠇
⠀⠀⢿⡄⠀⠀⠀⠀⠀⣿⠀⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⣸⠀⠀⠀⠀⠀⢀⣀⣀⠈⢧⣌⣉⣋⣴⠃⠀⢸⣴⠏⠀
⠀⠀⢸⡇⠀⠀⠀⠀⠀⢹⣆⠘⢿⣿⣿⣿⣿⣿⣿⣿⠟⢠⠏⠀⠀⣰⣶⣿⣿⣿⣿⠀⠀⠈⠉⠉⠀⠀⠀⣿⠃⠀⠀
⠀⠀⠸⣷⠀⠀⠀⠀⠀⠀⠻⣦⡀⠙⠻⠿⠿⠿⠛⢁⣴⠏⠀⠀⠀⢸⡄⠀⠙⢿⣿⠀⠀⠀⠀⠀⠀⠀⢰⡏⠀⠀⠀
⠀⠀⠀⢹⣇⠀⠀⠀⠀⠀⠀⠈⠛⠶⣦⣤⣤⡴⠾⠋⠀⠀⠀⠀⠀⠈⣷⠀⠀⠀⢻⠀⠀⠀⠀⠀⠀⢀⡿⠀⠀⠀⠀
⠀⠀⠀⠀⢻⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠦⣤⣀⡀⠀⠀⠀⠀⠸⣧⡀⢀⡿⠀⠀⠀⠀⠀⢠⡾⠁⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠹⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠛⠳⢦⡄⠀⠀⠘⠻⠞⠃⠀⠀⠀⠀⣰⠟⠁⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠈⠻⣦⡀⠀⠀⠀⠀⠀⠀⣀⠀⠀⠀⢀⣀⣴⠞⠁⠀⠀⠀⠀⠀⠀⠀⢀⣠⠞⠁⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⢷⣤⣀⠀⠀⠀⠙⠛⠛⠛⠋⠉⠀⠀⠀⠀⠀⠀⠀⢀⣠⣴⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠻⣶⣦⣤⣀⣀⣀⣀⣀⣀⣀⣠⣤⣴⣶⠟⠋⠉⠈⠙⠛⢶⣄⡀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠞⠋⠉⠀⠀⠈⠉⠉⠉⢉⣹⡏⠁⠀⠀⠈⠛⢶⣤⣀⡀⠀⠀⠈⢻⣄⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠿⣦⣤⣤⣤⣤⡴⠶⠶⠛⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠛⠷⠶⠶⠟⠀⠀⠀";


                Console.WriteLine(jigglypuff);
            }

                float cRate = p.CaptureRate;
                float entrynumber = p.PokedexNumbers[0].EntryNumber;
                Console.WriteLine(p.Name + " has a capture rate of " + cRate + "!");
                Console.WriteLine(p.Name + " has a pokedex number of " + entrynumber + "!");
                //string imageUrl = $"http://pokeapi.co/media/sprites/pokemon/{p}.png";
                //Console.WriteLine(imageUrl);

                string imageUrl = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{entrynumber}.png";

                // Create a BitmapImage object to load the image from the URL
                //BitmapImage image = new BitmapImage(new Uri(imageUrl));

                
                //p.EvolutionChain

                Console.WriteLine("The image url of this pokemon is: " + imageUrl);
            
        }
        catch (HttpRequestException e) when (e.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            Console.WriteLine("Pokemon species not found.");
        }
       
    }

}