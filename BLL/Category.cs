using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject2021.DAL;

namespace FinalProject2021.BLL
{
    public class Category
    {
        private int categoryID;
        private string categoryName;

        public int CategoryID { get => categoryID; set => categoryID = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }

        public List<Category> GetAllCategories()
        {
            return CategoryDB.GetAllRecords();
        }

        public void SaveCategories(Category cat)
        {
            CategoryDB.SaveRecord(cat);
        }

        public Category SearchCategoryID(int ctID)
        {
            return CategoryDB.SearchRecord(ctID);
        }

    }
}
