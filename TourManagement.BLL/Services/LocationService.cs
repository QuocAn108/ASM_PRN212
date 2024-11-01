using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagement.DAL.Model;
using TourManagement.DAL.Repositories;

namespace TourManagement.BLL.Services
{
    public class LocationService
    {
        private LocationRepository _locationRepo = new();
        public List<Location> GetAllLocation()
        {
           return _locationRepo.GetAll();
        }
        public void AddLocation(Location x)
        {
            _locationRepo.Add(x);
        }
        public void UpdateLocation(Location x)
        {
            _locationRepo.Update(x);
        }

        public void DeleteLocation(Location x)
        {
            _locationRepo.Delete(x);
        }
    }
}
