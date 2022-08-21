using ConsoleTables;
using Newtonsoft.Json;
using PokeAPIConsume.Models.Location_Model;

namespace PokeAPIConsume
{
    internal class RequestRegion : IRequestService
    {
        private readonly HttpClient client = new HttpClient();
        public List<LocationModel> listLocation = new List<LocationModel>();
        public RequestPokemon requestPokemon = new RequestPokemon();
        public int countFunctionCall = 0;
        public int countLocationArea = 0;
        public bool checkPokemonIsPrinted = false;


        public async Task GetAllData(int ID)
        {
            GetLocationListData(ID);
            var table = new ConsoleTable("ID", "Location");
            string responseRegion = await client.GetStringAsync("https://pokeapi.co/api/v2/region/" + ID);
            var modelLocation = JsonConvert.DeserializeObject<GetLocation>(responseRegion);

            foreach (var model in modelLocation.locations)
            {
                var locationSplit = model.url.Split('/');
                var locationID = locationSplit[6];
                table.AddRow(locationID, model.name);
            }
            Console.WriteLine(table);
            Console.WriteLine("\nType location ID ore filter count of area(F+Count)");
        }

        public async Task GetSpecificData(int ID)
        {
            if (countFunctionCall.Equals(0))
            {
                GetSpecificLocations(ID);

            }
            else if (countFunctionCall.Equals(1) && checkPokemonIsPrinted == false)
            {
                GetSpecificLocations(ID);
            }
            else if (countFunctionCall.Equals(2) && checkPokemonIsPrinted == false || countFunctionCall.Equals(1) && checkPokemonIsPrinted == true)
            {
                requestPokemon.GetSpecificData(ID);
            }
            countFunctionCall++;
        }

        public void FilterData<T>(T ID)
        {
            var idtoString = ID.ToString();
            var idSplit = idtoString.Split('F');
            var id = idSplit[1];

            var filteredLocation = listLocation.FindAll(i => i.countLocationArea > Convert.ToInt32(id));
            var table = new ConsoleTable("ID", "Location");

            for (int i = 0; i < filteredLocation.Count; i++)
            {
                table.AddRow(filteredLocation[i].id, filteredLocation[i].location);
            }
            Console.WriteLine(table);
        }

        private async Task GetSpecificLocations(int ID)
        {
            var table = new ConsoleTable("ID", "Location");

            if (countFunctionCall.Equals(0))
            {
                string responseRegion = await client.GetStringAsync("https://pokeapi.co/api/v2/location/" + ID);
                var modelLocation = JsonConvert.DeserializeObject<GetSpecificLocation>(responseRegion);
                countLocationArea = Convert.ToInt32(modelLocation.areas.Length);

                if (countLocationArea.Equals(0))
                {
                    await GetPokemonFromArea(ID);
                    checkPokemonIsPrinted = true;

                }
                else
                {
                    foreach (var model in modelLocation.areas)
                    {
                        var locationID = model.url.Split('/');
                        table.AddRow(locationID[6], model.name);
                    }
                    Console.WriteLine(table);
                }

            }
            else if (countFunctionCall.Equals(1))
            {
                await GetPokemonFromArea(ID);
            }
        }

        private async Task GetPokemonFromArea(int ID)
        {
            var table = new ConsoleTable("ID", "Pokemon");

            string responseRegion = await client.GetStringAsync("https://pokeapi.co/api/v2/location-area/" + ID);
            var modelLocation = JsonConvert.DeserializeObject<GetLocationArea>(responseRegion);

            foreach (var model in modelLocation.pokemon_encounters)
            {
                var locationID = model.pokemon.url.Split('/');
                table.AddRow(locationID[6], model.pokemon.name);
            }
            Console.WriteLine(table);
        }

        private async Task GetLocationListData(int ID)
        {
            string responseRegion = await client.GetStringAsync("https://pokeapi.co/api/v2/region/" + ID);
            var modelLocation = JsonConvert.DeserializeObject<GetLocation>(responseRegion);

            foreach (var model in modelLocation.locations)
            {
                var locationSplit = model.url.Split('/');
                var locationID = locationSplit[6];
                var locationName = model.name;

                string responseArea = await client.GetStringAsync("https://pokeapi.co/api/v2/location/" + locationID);
                var modelArea = JsonConvert.DeserializeObject<GetSpecificLocation>(responseArea);
                var countArea = modelArea.areas.Length;

                LocationModel locationModel = new LocationModel(Convert.ToInt32(locationID), locationName, countArea);
                listLocation.Add(locationModel);
            }
        }

    }
}
