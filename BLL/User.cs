using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject2021.DAL;

namespace FinalProject2021.BLL
{
    public class User
    {
        private int userID;
        private string userPassword;
        private int employeeID;

        public int UserID { get => userID; set => userID = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
        public int EmployeeID { get => employeeID; set => employeeID = value; }


        public List<User> GetAllUsers()
        {
            return UserDB.GetAllRecords();
        }

        public void SaveUser(User us)
        {
           UserDB.SaveRecord(us);
        }

        public User SearchUser(int usId)
        {
            return UserDB.SearchRecord(usId);
        }
    }
}
