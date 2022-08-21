using PokeAPIConsume;
using System.Text.RegularExpressions;

namespace PokeApiConsume
{
    internal class Program
    {
        private readonly static List<string> listRegions = new List<string>(new string[] { "Kanto", "Johto", "Hoenn", "Sinnoh", "Unova", "Kalos", "Alola" });
        private static bool checkRestartApplication = false;

        static void Main(string[] args)
        {
            getUI();
            Console.ReadLine();
        }

        private static void getRegions()
        {
            int regionId = 1;
            Console.WriteLine("Wähle eine Region aus: ");

            foreach (var region in listRegions)
            {
                Console.WriteLine(regionId + "\t" + region);
                regionId++;
            }
            Console.Write("{0}", "\n");
        }

        private static void restartApplication()
        {
            Console.WriteLine("\n restart? (y)\n");
            var selectionRestart = Console.ReadLine();

            if (selectionRestart.Equals("y"))
                checkRestartApplication = true;
        }

        private static void getUI()
        {
            Manager manager = new Manager();


            do
            {
                Console.Clear();
                Console.WriteLine("Auswahl welche Funktion: Pokemon(0) oder Region(1)\n");
                var selectionType = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (selectionType.Equals(0))
                {
                    RequestPokemon requestPokemon = new RequestPokemon();
                    manager = new Manager(requestPokemon);
                }
                else
                {
                    RequestRegion requestRegion = new RequestRegion();
                    manager = new Manager(requestRegion);
                }

                Console.Clear();
                getRegions();
                Console.Write("Auswahl Region: ");
                var regionInput = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                manager.getAllData(regionInput);


                if (selectionType.Equals(0))
                {
                    //Pokemon Function UI
                    var selection = Console.ReadLine();

                    if (Regex.IsMatch(selection, @"^\d+$"))
                    {
                        Console.Clear();
                        manager.getSpecificData(Convert.ToInt32(selection));
                        restartApplication();
                    }
                    else
                    {
                        Console.Clear();
                        manager.filterData(selection);

                        var selectionPokemonData = Console.ReadLine();
                        Console.Clear();
                        manager.getSpecificData(Convert.ToInt32(selectionPokemonData));
                        restartApplication();
                    }
                }
                else
                {
                    //Region Function UI
                    var selectionLocation = Console.ReadLine();
                    Console.Clear();


                    //Selection IF Filter ore get Areas
                    //Get Location Areas 

                    if (selectionLocation.StartsWith('F'))
                    {
                        //Filter aufrufen 
                        manager.filterData(selectionLocation);

                        var selectionLocationFilter = Console.ReadLine();
                        Console.Clear();
                        manager.getSpecificData(Convert.ToInt32(selectionLocationFilter));

                        try
                        {
                            var selectionLocationArea = Console.ReadLine();
                            Console.Clear();
                            manager.getSpecificData(Convert.ToInt32(selectionLocationArea));
                        }
                        catch { }

                        var selectionPokemonID = Console.ReadLine();
                        Console.Clear();
                        manager.getSpecificData(Convert.ToInt32(selectionPokemonID));

                        restartApplication();
                    }
                    else
                    {
                        //normale ansicht
                        manager.getSpecificData(Convert.ToInt32(selectionLocation));
                        try
                        {
                            var selectionLocationArea = Console.ReadLine();
                            Console.Clear();
                            manager.getSpecificData(Convert.ToInt32(selectionLocationArea));
                        }
                        catch { }

                        try
                        {
                            var selectionPokemonID = Console.ReadLine();
                            Console.Clear();
                            manager.getSpecificData(Convert.ToInt32(selectionPokemonID));
                        }
                        catch { }                      
                        restartApplication();
                    }

                }
            }
            while (checkRestartApplication == true);


        }

    }
}