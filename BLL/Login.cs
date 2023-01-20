using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject2021.DAL;

namespace FinalProject2021.BLL
{
    public class Login
    {
        private int employeeID;
        private string employeeFirstName;
        private string employeeLastName;
        private string employeePassword;
        private string employeePosition;
        private int employeeUserID;
        private string employeePhoneNumber;
        private string employeeEmail;

        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string EmployeeFirstName { get => employeeFirstName; set => employeeFirstName = value; }
        public string EmployeeLastName { get => employeeLastName; set => employeeLastName = value; }
        public string EmployeePassword { get => employeePassword; set => employeePassword = value; }
        public string EmployeePosition { get => employeePosition; set => employeePosition = value; }
        public int EmployeeUserID { get => employeeUserID; set => employeeUserID = value; }
        public string EmployeePhoneNumber { get => employeePhoneNumber; set => employeePhoneNumber = value; }
        public string EmployeeEmail { get => employeeEmail; set => employeeEmail = value; }

        public Login SearchEmployee(int id)
        {
            return LoginDB.SearchRecord(id);
        }

        public void UpdateP(Login lg)
        {
            LoginDB.UpdateP(lg);
        }

    }
}
