using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Temperature_and_Humidity_Collection.Data;
using Temperature_and_Humidity_Collection.Models;

namespace Temperature_and_Humidity_Collection
{
    
    public class DBContextTest
    {
        public void AddData()
        {
            using(var context = new MyDbContext())
            {
                var new_user = new UserInformationTable()
                {
                    UserAccount = "123456",
                    UserPassword = "123456",
                    UserName = "Test",
                    UserAccessLevel = 1
                };

                context.UserInformationTables.Add(new_user);
                context.SaveChanges();
            }
        }

        public void DeleteData()
        {
            using (var context = new MyDbContext())
            {
                var user = context.UserInformationTables.FirstOrDefault(e=>e.UserName == "Test001");
                if (user != null)
                {
                    context.UserInformationTables.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateData()
        {
            using (var context = new MyDbContext())
            {
                var user = context.UserInformationTables.FirstOrDefault(e => e.UserName == "Test");
                if (user != null)
                {
                    user.UserName = "Test001";
                    context.SaveChanges();
                }
            }
        }

        public UserInformationTable FindData()
        {
            using (var context = new MyDbContext())
            {
                var user = context.UserInformationTables.FirstOrDefault(e => e.UserName == "Test");
                return user;
            }
        }
    }

}
