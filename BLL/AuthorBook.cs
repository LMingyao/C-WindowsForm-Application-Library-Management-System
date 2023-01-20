using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject2021.DAL;

namespace FinalProject2021.BLL
{
    public class AuthorBook
    {
        int authorID;
        string firstName;
        string lastName;
        string email;
        string iSBN;
        string yearPublished;
        string edition;

        public int AuthorID { get => authorID; set => authorID = value; }
        public string ISBN { get => iSBN; set => iSBN = value; }
        public string YearPublished { get => yearPublished; set => yearPublished = value; }
        public string Edition { get => edition; set => edition = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }

        public List<AuthorBook> GetAllAuthorBooks()
        {
            return AuthorBookDB.GetAllRecords();
        }

        public AuthorBook SearchABID(int abId)
        {
            return AuthorBookDB.SearchRecordABID(abId);
        }

        public AuthorBook SearchISBN(string ISBNid)
        {
            return AuthorBookDB.SearchRecordISBN(ISBNid);
        }

        public void SaveAuthorBook(AuthorBook ab)
        {
            AuthorBookDB.SaveRecord(ab);
        }
    }
}
