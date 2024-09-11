using Microsoft.EntityFrameworkCore;
using SHEndevour.Models;
using SHEndevour.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHEndevour.Repositories.Reports
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<UserModel> GetAllUsers()
        {
            return _context.Users.Include(u => u.Role).ToList();
        }
    }

}
