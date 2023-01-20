using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject2021.DAL;

namespace FinalProject2021.BLL
{
    public class Publisher
    {
        private int publisherID;
        private string publisherName;
        private string webAddress;

        public int PublisherID { get => publisherID; set => publisherID = value; }
        public string PublisherName { get => publisherName; set => publisherName = value; }
        public string WebAddress { get => webAddress; set => webAddress = value; }

        public List<Publisher> GetAllPublishers()
        {
            return PublisherDB.GetAllRecords();
        }
        public void SavePublishers(Publisher pub)
        {
            PublisherDB.SaveRecord(pub);
        }

        public Publisher SearchPublisherID(int pbID)
        {
            return PublisherDB.SearchRecord(pbID);
        }
    }
}
