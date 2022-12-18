using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMediiMAUI.Models
{
    public class SalonList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(200), Unique]
        public string Name { get; set; }

        [MaxLength(500), Unique]
        public string Description { get; set; }
    }
}
