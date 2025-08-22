using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Temperature_and_Humidity_Collection
{
    internal class DBContextLib : DbContext
    {

        string dbContextStr = "Data Source=喵内;Initial Catalog=Temperature-and-Humidity-Collection;Integrated Security=True;Encrypt=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(dbContextStr);
        }
    }
}
