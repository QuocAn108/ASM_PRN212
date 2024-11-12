using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagement.DAL.Model;
using TourManagement.DAL.Repositories;

namespace TourManagement.BLL.Services
{
    public class TourDestinationService
    {
        private TourDestinationRepository _tdRepo = new();
        public List<TourDestination> GetAllTD()
        {
            return _tdRepo.GetAll();
        }

    }
}
