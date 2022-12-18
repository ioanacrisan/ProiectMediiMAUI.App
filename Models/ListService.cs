using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProiectMediiMAUI.Models
{
    public class ListService
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(SalonList))]
        public int SalonListID { get; set; }
        public int ServiceID { get; set; }
    }
}
