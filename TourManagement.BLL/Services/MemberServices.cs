using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagement.DAL.Model;
using TourManagement.DAL.Repositories;

namespace TourManagement.BLL.Services
{
    public class MemberServices
    {
        private MemberRepository  _memberRepo = new();
        public Member? CheckLogin(string email, string password)
        {
            return _memberRepo.GetUser(email, password);
        }
    }
}
