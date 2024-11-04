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

        public List<Tour> GetAllTour()
        {
            return _TourRepo.GetAllTour();
        }
        public void AddTour(Tour x)
        {
            _TourRepo.AddTour(x);
        }
        public void UpdateTour(Tour x)
        {
            _TourRepo.UpdateTour(x);
        }

        public void DeleteTour(Tour x)
        {
            _TourRepo.DeleteTour(x);
        }
    }
}
