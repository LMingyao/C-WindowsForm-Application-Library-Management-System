using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject2021.DAL;

namespace FinalProject2021.BLL
{
    public class Author
    {
        int authorID;
        string firstName;
        string lastName;
        string email;

        public int AuthorID { get => authorID; set => authorID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }

        public List<Author> GetAllAuthors()
        {
            return AuthorDB.GetAllRecords();
        }

        public Author SearchAuthor(int auId)
        {
            return AuthorDB.SearchRecord(auId);
        }

        public void SaveAuthors(Author aut)
        {
            AuthorDB.SaveRecord(aut);
        }
    }
}
