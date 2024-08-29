using PokeAPI;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using Microsoft.AspNetCore.Mvc;

class Program
{
    public static async Task Main(string[] args)
    {
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
                //Console.WriteLine("Pick a number to the see the stats:");


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

                if (pokemonspecies == "charizard")
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

            if (pokemonspecies == "pikachu")
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

            if (pokemonspecies == "squirtle")
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

            if (pokemonspecies == "bulbasaur")
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

            float cRate = p.CaptureRate;
                    float entrynumber = p.PokedexNumbers[0].EntryNumber;
                    Console.WriteLine(p.Name + " has a capture rate of " + cRate + "!");
                    Console.WriteLine(p.Name + " has a pokedex number of " + entrynumber + "!");
                    //string imageUrl = $"http://pokeapi.co/media/sprites/pokemon/{p}.png";
                    //Console.WriteLine(imageUrl);



                    //p.EvolutionChain
                
           
        }
        catch (HttpRequestException e) when (e.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            Console.WriteLine("Pokemon species not found.");
        }
       
    }

}