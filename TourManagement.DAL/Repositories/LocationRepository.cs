using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagement.DAL.Data;
using TourManagement.DAL.Model;

namespace TourManagement.DAL.Repositories
{
    public class LocationRepository
    {
        private ApplicationDBContext _context;
        public List<Location> GetAll()
        {
            _context = new ApplicationDBContext();
            return _context.Locations.ToList();
        }
        public void Add(Location x)
        {
            _context = new();
            _context.Locations.Add(x);
            _context.SaveChanges();
        }
        public void Update(Location x)
        {
            _context = new();
            _context.Locations.Update(x);  
            _context.SaveChanges();         
        }

        public void Delete(Location x)
        {
            _context = new();
            _context.Locations.Remove(x); 
            _context.SaveChanges();           
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
