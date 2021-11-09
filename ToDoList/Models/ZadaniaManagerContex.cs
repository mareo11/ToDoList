using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class ZadaniaManagerContex : DbContext
    {
        public ZadaniaManagerContex(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ZadaniaModelcs> Zadanias{ get; set; }
    }
}
