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
            _database.CreateTableAsync<Service>().Wait();
            _database.CreateTableAsync<ListService>().Wait();
            _database.CreateTableAsync<Salon>().Wait();
        }
        public Task<int> SaveServiceAsync(Service service)
        {
            if (service.ID != 0)
            {
                return _database.UpdateAsync(service);
            }
            else
            {
                return _database.InsertAsync(service);
            }
        }
        public Task<int> DeleteServiceAsync(Service service)
        {
            return _database.DeleteAsync(service);
        }
        public Task<List<Service>> GetServicesAsync()
        {
            return _database.Table<Service>().ToListAsync();
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

        public Task<int> SaveListServiceAsync(ListService listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Service>> GetListServicesAsync(int salonlistid)
        {
            return _database.QueryAsync<Service>(
            "select P.ID, P.Description from Service P"
            + " inner join ListService LP"
            + " on P.ID = LP.ServiceID where LP.SalonListID = ?",
            salonlistid);
        }


        public Task<List<Salon>> GetSalonsAsync()
        {
            return _database.Table<Salon>().ToListAsync();
        }
        public Task<int> SaveSalonAsync(Salon salon)
        {
            if (salon.ID != 0)
            {
                return _database.UpdateAsync(salon);
            }
            else
            {
                return _database.InsertAsync(salon);
            }
        }

    }
}
