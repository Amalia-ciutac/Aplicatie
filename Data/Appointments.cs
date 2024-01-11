using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicatie.Models;

namespace Aplicatie.Data
{
    public class AppointmentsDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public AppointmentsDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Appointment>().Wait();
        }

        public Task<List<Appointment>> GetAppointmentsAsync()
        {
            return _database.Table<Appointment>().ToListAsync();
        }

        public Task<Appointment> GetAppointmentAsync(int id)
        {
            return _database.Table<Appointment>()
                            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }

        public Task<int> SaveAppointmentAsync(Appointment appointment)
        {
            if (appointment.ID != 0)
            {
                return _database.UpdateAsync(appointment);
            }
            else
            {
                return _database.InsertAsync(appointment);
            }
        }

        public Task<int> DeleteAppointmentAsync(Appointment appointment)
        {
            return _database.DeleteAsync(appointment);
        }
    }
}
