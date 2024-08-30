﻿using PokeAPI;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using Windows.UI.Xaml.Media.Imaging;
using System.Drawing;
using Spectre.Console;
using System.ComponentModel.Design;

class Program
{
    public static async Task Main()
    {
        //nice title screen

        Console.ForegroundColor = ConsoleColor.Yellow;
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
        await startGame();
    }

    public static async Task startGame()
    {
        Console.WriteLine("Enter the name of a Pokemon to see its stats! Enter quit to quit.");
        var p = Console.ReadLine()?.ToLower();
        bool hasArt = false;
        if (p == "quit")
        {
            quitGame();
        }
        else if (!await isRealPoke(p))
        {
            await startGame();
        }
                    await PrintPoke(p.ToLower());
        bool quit2 = false;
        while (!quit2)
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Pick a number to the see the stats for " + p + ":");
            Console.WriteLine("1. Basic Info (Capture Rate & Pokedex Number)");
            Console.WriteLine("2. Female to Male Ratio");
            Console.WriteLine("3. Base Happiness");
            Console.WriteLine("4. All of the above");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Q. Quit Game");
            Console.WriteLine("R. Restart");
            if (!hasArt) { Console.ForegroundColor = ConsoleColor.White; }
            var x = Console.ReadLine()?.ToLower();
            switch (x)
            { 
                case "1":
                    await GetPokemon(p.ToLower());
                    break;
                case "2":
                    await GetFemaletoMaleRate(p.ToLower());
                    break;
                case "3":
                    await GetBaseHappiness(p.ToLower());
                    break;
                case "4":
                    await GetPokemon(p.ToLower());
                    await GetFemaletoMaleRate(p);
                    await GetBaseHappiness(p);
                    break;
                case "q":
                    quit2 = true;
                    quitGame();
                    break;
                case "r":
                    // Console.WriteLine("Case 6 entered.");
                    quit2 = true;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    await startGame();
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again!");
                    break;
                }
                // System.Threading.Thread.Sleep(2000); Console.Clear();
            }
    }

    public static async Task GetFemaletoMaleRate(string pokemonspecies)
    {
        try
        {
            PokemonSpecies p = await DataFetcher.GetNamedApiObject<PokemonSpecies>(pokemonspecies);

            float? r = p.FemaleToMaleRate;

            Console.WriteLine(p.Name + " has a female to male rate of " + r + "!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while fetching the female to male rate: " + ex.Message);
        }
    }

    public static async Task GetBaseHappiness(string pokemonspecies)
    {
        try
        {
            PokemonSpecies p = await DataFetcher.GetNamedApiObject<PokemonSpecies>(pokemonspecies);

            int r = p.BaseHappiness;

            Console.WriteLine(p.Name + " has a base happiness of " + r + "!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while fetching the base happiness: " + ex.Message);
        }
    }


    public static async Task GetPokemon(string pokemonspecies)
    {

        //Console.WriteLine("hi");

        //PokemonSpecies p = await DataFetcher.GetApiObject<PokemonSpecies>(395);

        try
        {
            PokemonSpecies p = await DataFetcher.GetNamedApiObject<PokemonSpecies>(pokemonspecies);


            float cRate = p.CaptureRate;
            float entrynumber = p.PokedexNumbers[0].EntryNumber;
            Console.WriteLine(p.Name + " has a capture rate of " + cRate + "!");
            Console.WriteLine(p.Name + " has a pokedex number of " + entrynumber + "!");
            string imageUrl = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{entrynumber}.png";
            // Create a BitmapImage object to load the image from the URL
            //BitmapImage image = new BitmapImage(new Uri(imageUrl));

            Console.WriteLine("The image url of this pokemon is: " + imageUrl);

        }

        catch (HttpRequestException e) when (e.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            Console.WriteLine("Pokemon species not found.");
        }

    }

    public static async Task<bool> isRealPoke(string pokemonspecies)
    {
        try
        {
            PokemonSpecies p = await DataFetcher.GetNamedApiObject<PokemonSpecies>(pokemonspecies);


            return true;

        }

        catch (HttpRequestException e) when (e.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            Console.WriteLine("Pokemon species not found.");
            return false;

        }

    }
    public static void quitGame() {
        Console.WriteLine("Thanks for playing!");
        System.Threading.Thread.Sleep(1500); System.Environment.Exit(0);
    }

    public static async Task PrintPoke(string pokemonspecies){
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

            else if (pokemonspecies == "charizard")
            {

                    Console.ForegroundColor = ConsoleColor.Red;
                    string charizard = @"
.""-,.__
                 `.     `.  ,
              .--'  .._,'""-' `.
             .    .'         `'
             `.   /          ,'
               `  '--.   ,-""'
                `""`   |  \
                   -. \, |
                    `--Y.'      ___.
                         \     L._, \
               _.,        `.   <  <\                _
             ,' '           `, `.   | \            ( `
          ../, `.            `  |    .\`.           \ \_
         ,' ,..  .           _.,'    ||\l            )  '"".
        , ,'   \           ,'.-.`-._,'  |           .  _._`.
      ,' /      \ \        `' ' `--/   | \          / /   ..\
    .'  /        \ .         |\__ - _ ,'` `        / /     `.`.
    |  '          ..         `-...-""  |  `-'      / /        . `.
    | /           |L__           |    |          / /          `. `.
   , /            .   .          |    |         / /             ` `
  / /          ,. ,`._ `-_       |    |  _   ,-' /               ` \
 / .           \""`_/. `-_ \_,.  ,'    +-' `-'  _,        ..,-.    \`.
.  '         .-f    ,'   `    '.       \__.---'     _   .'   '     \ \
' /          `.'    l     .' /          \..      ,_|/   `.  ,'`     L`
|'      _.-""""` `.    \ _,'  `            \ `.___`.'""`-.  , |   |    | \
||    ,'      `. `.   '       _,...._        `  |    `/ '  |   '     .|
||  ,'          `. ;.,.---' ,'       `.   `.. `-'  .-' /_ .'    ;_   ||
|| '              V      / /           `   | `   ,'   ,' '.    !  `. ||
||/            _,-------7 '              . |  `-'    l         /    `||
. |          ,' .-   ,' ||               | .-.        `.      .'     ||
 `'        ,'    `"".'    |               |    `.        '. -.'       `'
          /      ,'      |               |,'    \-.._,.'/'
          .     /        .               .       \    .''
        .`.    |         `.             /         :_,'.'
          \ `...\   _     ,'-.        .'         /_.-'
           `-.__ `,  `'   .  _.>----''.  _  __  /
                .'        /""'          |  ""'   '_
               /_|.-'\ ,"".             '.'`__'-( \
                 / ,""'""\,'               `/  `-.|"" ";

                    Console.WriteLine(charizard);
                }
  
            else if (pokemonspecies == "pikachu")
            {

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    string pikachu = @"
quu..__
 $$$b  `---.__
  ""$$b        `--.                          ___.---uuudP
   `$$b           `.__.------.__     __.---'      $$$$""              .
     ""$b          -'            `-.-'            $$$""              .'|
       "".                                       d$""             _.'  |
         `.   /                              ...""             .'     |
           `./                           ..::-'            _.'       |
            /                         .:::-'            .-'         .'
           :                          ::''\          _.'            |
          .' .-.             .-.           `.      .'               |
          : /'$$|           .@""$\           `.   .'              _.-'
         .'|$u$$|          |$$,$$|           |  <            _.-'
         | `:$$:'          :$$$$$:           `.  `.       .-'
         :                  `""--'             |    `-.     \
        :##.       ==             .###.       `.      `.    `\
        |##:                      :###:        |        >     >
        |#'     `..'`..'          `###'        x:      /     /
         \                                   xXX|     /    ./
          \                                xXXX'|    /   ./
          /`-.                                  `.  /   /
         :    `-  ...........,                   | /  .'
         |         ``:::::::'       .            |<    `.
         |             ```          |           x| \ `.:``.
         |                         .'    /'   xXX|  `:`M`M':.
         |    |                    ;    /:' xXXX'|  -'MMMMM:'
         `.  .'                   :    /:'       |-'MMMM.-'
          |  |                   .'   /'        .'MMM.-'
          `'`'                   :  ,'          |MMM<
            |                     `'            |tbap\
             \                                  :MM.-'
              \                 |              .''
               \.               `.            /
                /     .:::::::.. :           /
               |     .:::::::::::`.         /
               |   .:::------------\       /
              /   .''               >::'  /
              `',:                 :    .'
                                   `:.:'";

                    Console.WriteLine(pikachu);
                }

            else if (pokemonspecies == "squirtle")
            {

                    Console.ForegroundColor = ConsoleColor.Blue;
                    string squirtle = @"
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀     _,........__
            ,-'            ""`-.
          ,'                   `-.
        ,'                        \
      ,'                           .
      .'\               ,"""".       `
     ._.'|             / |  `       \
     |   |            `-.'  ||       `.
     |   |            '-._,'||       | \
     .`.,'             `..,'.'       , |`-.
     l                       .'`.  _/  |   `.
     `-.._'-   ,          _ _'   -"" \  .     `
`.""""""""""'-.`-...,---------','         `. `....__.
.'        `""-..___      __,'\          \  \     \
\_ .          |   `""""""""'    `.           . \     \
  `.          |              `.          |  .     L
    `.        |`--...________.'.        j   |     |
      `._    .'      |          `.     .|   ,     |
         `--,\       .            `7""""' |  ,      |
            ` `      `            /     |  |      |    _,-'""""""`-.
             \ `.     .          /      |  '      |  ,'          `.
              \  v.__  .        '       .   \    /| /              \
               \/    `""""\""""""""""""""`.       \   \  /.''                |
                `        .        `._ ___,j.  `/ .-       ,---.     |
                ,`-.      \         .""     `.  |/        j     `    |
               /    `.     \       /         \ /         |     /    j
              |       `-.   7-.._ .          |""          '         /
              |          `./_    `|          |            .     _,'
              `.           / `----|          |-............`---'
                \          \      |          |
               ,'           )     `.         |
                7____,,..--'      /          |
                                  `---.__,--.'mh";

                    Console.WriteLine(squirtle);
                }
            else if (pokemonspecies == "bulbasaur")
            {

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    string bulbasaur = @"
                                           /
                        _,.------....___,.' ',.-.
                     ,-'          _,.--""        |
                   ,'         _.-'              .
                  /   ,     ,'                   `
                 .   /     /                     ``.
                 |  |     .                       \.\
       ____      |___._.  |       __               \ `.
     .'    `---""""       ``""-.--""'`  \               .  \
    .  ,            __               `              |   .
    `,'         ,-""'  .               \             |    L
   ,'          '    _.'                -._          /    |
  ,`-.    ,"".   `--'                      >.      ,'     |
 . .'\'   `-'       __    ,  ,-.         /  `.__.-      ,'
 ||:, .           ,'  ;  /  / \ `        `.    .      .'/
 j|:D  \          `--'  ' ,'_  . .         `.__, \   , /
/ L:_  |                 .  ""' :_;                `.'.'
.    """"'                  """"""""""'                    V
 `.                                 .    `.   _,..  `
   `,_   .    .                _,-'/    .. `,'   __  `
    ) \`._        ___....----""'  ,'   .'  \ |   '  \  .
   /   `. ""`-.--""'         _,' ,'     `---' |    `./  |
  .   _  `""""'--.._____..--""   ,             '         |
  | ."" `. `-.                /-.           /          ,
  | `._.'    `,_            ;  /         ,'          .
 .'          /| `-.        . ,'         ,           ,
 '-.__ __ _,','    '`-..___;-...__   ,.'\ ____.___.'
 `""^--'..'   '-`-^-'""--    `-^-'`.''""""""""""`.,^.`.--'";

                    Console.WriteLine(bulbasaur);
            }
        else
        {
            try
            {
                PokemonSpecies p = await DataFetcher.GetNamedApiObject<PokemonSpecies>(pokemonspecies);


                float cRate = p.CaptureRate;
                float entrynumber = p.PokedexNumbers[0].EntryNumber;
                string imageUrl = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{entrynumber}.png";
                string localPath = $"pokemon-{pokemonspecies}";
                using (HttpClient client = new HttpClient())
                {
                    byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);
                    await File.WriteAllBytesAsync(localPath, imageBytes);
                }
                var image = new CanvasImage(localPath);
                image.MaxWidth(40);
                AnsiConsole.Write(image);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



//nice art, I like the style and the game was interesting

//only thing I would say is to add comments so it can be easy for people to use the API Wrapper

