using ParkyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyApi.Repository.IRepository
{
    public interface INationalParkRepository
    {
        ICollection<NatinalPark> GetNationalParks();
        NatinalPark GetNatinalPark(int natinalParkId);
        bool NationalParkExists(string name);
        bool NationalParkExists(int id);
        bool CreateNationalPark(NatinalPark natinalPark);
        bool UpdateNationalPark(NatinalPark natinalPark);
        bool DeleteNationalPark(NatinalPark natinalPark);

        bool Save();

    }
}
