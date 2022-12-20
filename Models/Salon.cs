using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMediiMAUI.Models
{
    public class Salon
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string SalonName { get; set; }
        public string Adress { get; set; }
        public string SalonDetails
        {
            get
            {
                return SalonName + " "+Adress;} }

        [OneToMany]
public List<SalonList> SalonLists { get; set; }
    }
}
