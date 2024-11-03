using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagement.DAL.Model;
using TourManagement.DAL.Repositories;

namespace TourManagement.BLL.Services
{
    public class TourService
    {
        private TourRepository _TourRepo = new();

        public List<Tour> GetAllLocation()
        {
            return _TourRepo.GetAllTour();
        }
        public void AddLocation(Tour x)
        {
            _TourRepo.AddTour(x);
        }
        public void UpdateLocation(Tour x)
        {
            _TourRepo.UpdateTour(x);
        }

        public void DeleteLocation(Tour x)
        {
            _TourRepo.DeleteTour(x);
        }
    }
}
