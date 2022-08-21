using ConsoleTables;
using Newtonsoft.Json;
using PokeAPIConsume.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPIConsume
{
    public class RequestPokemon : IRequestService
    {
        private readonly HttpClient client = new HttpClient();
        public List<PokemonModel> listPokemon = new List<PokemonModel>();

        public async Task GetAllData(int ID)
        {
            string consoleOutput = "\nSelect Pokemon ID ore filter type: ";
            await GetPokemon(ID);
            printPokemon(listPokemon, consoleOutput);
        }

        public async Task GetSpecificData(int ID)
        {
            //Weitere UI einfügen 
            var url = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + ID + ".png";
            Process.Start("explorer", url);

            string response = await client.GetStringAsync("https://pokeapi.co/api/v2/pokemon/" + ID);
            var myModel = JsonConvert.DeserializeObject<PokemonData>(response);

            Console.WriteLine("Name: {0} {1}", myModel.name, "\n");


            Console.Write("{0}", "Types:");
            foreach (var item in myModel.types)
            {
                Console.Write("{0} {1} {2}", "\t", item.type.name, "\n");
            }


            Console.Write("{0}", "\n");

            foreach (var item in myModel.moves)
            {
                int index = 0;
                if (item.version_group_details[index].level_learned_at != 0)
                {
                    Console.WriteLine("Lvl:\t" + item.version_group_details[index].level_learned_at + "\t" + item.move.name);
                }
                index++;
            }
        }

        public void FilterData<T>(T ID)
        {
            var filteredPokemon = listPokemon.FindAll(t => t.types.Contains(ID.ToString()));
            string consoleOutput = "\nSelect Pokemon ID: ";
            printPokemon(filteredPokemon, consoleOutput);
        }

        private void printPokemon(List<PokemonModel> pokemon, string consoleOutput)
        {
            var table = new ConsoleTable("ID", "Name", "Type");
            var type = string.Empty;

            for (int i = 0; i < pokemon.Count; i++)
            {
                type = pokemon[i].types[0];

                if (pokemon[i].types.Count > 1)
                {
                    type = pokemon[i].types[0] + ", " + pokemon[i].types[1];

                }
                table.AddRow(pokemon[i].id, pokemon[i].name, type);
            }
            Console.WriteLine(table);
            Console.WriteLine(consoleOutput);
        }

        private async Task GetPokemon(int RegionID)
        {
            string responseRegion = await client.GetStringAsync("https://pokeapi.co/api/v2/generation/" + RegionID);
            var modelRegion = JsonConvert.DeserializeObject<PokemonRegion>(responseRegion);

            foreach (var itemRegion in modelRegion.pokemon_species)
            {
                var splittedID = itemRegion.url.Split('/');

                string responsePokemon = await client.GetStringAsync("https://pokeapi.co/api/v2/pokemon/" + splittedID[6]);
                var modelPokemon = JsonConvert.DeserializeObject<PokemonData>(responsePokemon);
                var typeList = new List<string>();


                for (int i = 0; i < modelPokemon.types.Length; i++)
                {
                    typeList.Add(modelPokemon.types[i].type.name);
                }

                listPokemon.Add(new PokemonModel(Convert.ToInt32(splittedID[6]), itemRegion.name, typeList));
            }
        }

    }
}