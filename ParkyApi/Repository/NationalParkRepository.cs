using ParkyApi.Data;
using ParkyApi.Models;
using ParkyApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyApi.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly DataContext _db;
        public NationalParkRepository(DataContext db)
        {
            _db = db;
        }
        public bool CreateNationalPark(NatinalPark natinalPark)
        {
            _db.NatinalPark.Add(natinalPark);
            return Save();
        }

        public bool DeleteNationalPark(NatinalPark natinalPark)
        {
            _db.NatinalPark.Remove(natinalPark);
            return Save();
        }

        public NatinalPark GetNatinalPark(int natinalParkId)
        {
            return _db.NatinalPark.FirstOrDefault(a => a.Id == natinalParkId); 
        }

        public ICollection<NatinalPark> GetNationalParks()
        {
            return _db.NatinalPark.OrderBy(a => a.Name).ToList();
        }

        public bool NationalParkExists(string name)
        {
            bool value = _db.NatinalPark.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool NationalParkExists(int id)
        {
            return _db.NatinalPark.Any(a => a.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateNationalPark(NatinalPark natinalPark)
        {
            _db.NatinalPark.Update(natinalPark);
            return Save();
        }
    }
}
