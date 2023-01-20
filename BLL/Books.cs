using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject2021.DAL;
using FinalProject2021.GUI;

namespace FinalProject2021.BLL
{
    public class Books
    {
        string iSBN;
        string title;
        int unitPrice;
        string yearPublished;
        int qOH;
        int categoryID;
        int publisherID;

        public string ISBN { get => iSBN; set => iSBN = value; }
        public string Title { get => title; set => title = value; }
        public int UnitPrice { get => unitPrice; set => unitPrice = value; }
        public string YearPublished { get => yearPublished; set => yearPublished = value; }
        public int QOH { get => qOH; set => qOH = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public int PublisherID { get => publisherID; set => publisherID = value; }

        public List<Books> GetAllBooks()
        {
            return BooksDB.GetAllRecords();
        }

        public Books SearchBooks(string bookNUM)
        {
            return BooksDB.SearchRecord(bookNUM);
        }
        public void SaveBooks(Books boo)
        {
           BooksDB.SaveRecord(boo);
        }



    }
}
