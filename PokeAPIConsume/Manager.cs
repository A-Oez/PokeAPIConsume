using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PokeAPIConsume
{
    public class Manager
    {
        public readonly IRequestService _requestService;

        public Manager(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public Manager()
        {
        }

        public void getAllData(int ID)
        {
            _requestService.GetAllData(ID);
        }

        public void filterData(string typeInput)
        {
            _requestService.FilterData(typeInput);
        }


        public void getSpecificData(int pokemonInput)
        {
            _requestService.GetSpecificData(pokemonInput);
        }

    }
}
