using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagement.DAL.Data;
using TourManagement.DAL.Model;

namespace TourManagement.DAL.Repositories
{
    public class TourRepository
    {
        private ApplicationDBContext? _context;

        public List<Tour> GetAllTour()
        {
            _context = new();
            return _context.Tours.ToList();
        }
        public void AddTour(Tour x)
        {
            _context = new();
            _context.Tours.Add(x);
            _context.SaveChanges();
        }

        public void UpdateTour(Tour x)
        {
            _context = new();
            _context.Tours.Update(x);
            _context.SaveChanges();
        }

        public void DeleteTour(Tour x)
        {
            _context = new();
            _context.Tours.Remove(x);
            _context.SaveChanges();
        }




    }
}
