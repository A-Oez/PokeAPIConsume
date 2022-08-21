using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPIConsume
{
    public interface IRequestService
    {
        public Task GetAllData(int ID);
        public Task GetSpecificData(int ID);

        public void FilterData<T>(T ID);

    }
}
