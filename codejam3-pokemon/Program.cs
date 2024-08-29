using PokeAPI;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using Microsoft.AspNetCore.Mvc;

class Program
{
    public static void Main(string[] args)
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

        GetPokemon("pikachu");

    }

    public static async void GetPokemon(string pokemonspecies)
    {

        Console.WriteLine("hi");

        //PokemonSpecies p = await DataFetcher.GetApiObject<PokemonSpecies>(395);

        PokemonSpecies p = await DataFetcher.GetNamedApiObject<PokemonSpecies>(pokemonspecies);

        float cRate = p.CaptureRate;
        
        Console.WriteLine(p.Name + " has a capture rate of " + cRate + "!");

       
    }

}