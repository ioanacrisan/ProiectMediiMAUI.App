using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProiectMediiMAUI.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMediiMAUI.Data
{
    public class SalonListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public SalonListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<SalonList>().Wait();
        }
        public Task<List<SalonList>> GetSalonListsAsync()
        {
            return _database.Table<SalonList>().ToListAsync();
        }
        public Task<SalonList> GetSalonListAsync(int id)
        {
            return _database.Table<SalonList>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveSalonListAsync(SalonList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteSalonListAsync(SalonList slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
