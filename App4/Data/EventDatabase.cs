using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System;
using Xamarin.Forms;

namespace App4.Data
{
    public class EventDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public EventDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<PersonData>().Wait();
            _database.CreateTableAsync<EventData>().Wait();
            _database.CreateTableAsync<PersonEvent>().Wait();
        }
        // General EVENT Database Actions
        public Task<List<EventData>> GetEventsAsync()
        {
            return _database.Table<EventData>().ToListAsync();
        }

        public Task<EventData> GetEventAsync(string name)
        {
            return _database.Table<EventData>()
                            .Where(i => i.Name == name)
                            .FirstOrDefaultAsync();
        }
        public Task<int> SaveEventAsync(EventData MyEvent)
        {
            if (MyEvent != null)
            {
                return _database.InsertAsync(MyEvent);
            }
            else
            {
                return _database.UpdateAsync(MyEvent);
            }
        }
        // General PERSON Database Actions
        public Task<List<PersonData>> GetPersonAsync()
        {
            return _database.Table<PersonData>().ToListAsync();
        }

        public Task<PersonData> GetPersonAsync(string name)
        {
            return _database.Table<PersonData>()
                            .Where(i => i.UserName == name)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SavePersonAsync(PersonData MyPerson)
        {
            if (MyPerson != null)
            {
                return _database.InsertAsync(MyPerson);
            }
            else
            {
                return _database.UpdateAsync(MyPerson);
            }
        }
        // General PERSON-EVENT Database Actions
        public Task<List<PersonEvent>> GetPersonEventAsync()
        {
            return _database.Table<PersonEvent>().ToListAsync();
        }

        public Task<PersonEvent> GetPersonEventAsync(string name)
        {
            return _database.Table<PersonEvent>()
                            .Where(i => i.PersonName == name)
                            .FirstOrDefaultAsync();
        }


        public Task<List<PersonEvent>> GetPeopleEventAsync(string name)
        {
            return _database.Table<PersonEvent>().Where(e => e.EventTitle.Equals(name)).ToListAsync();
        }

        public Task<int> SavePersonEventAsync(PersonEvent personevent)
        {
            if (personevent.PersonName != null)
            {
                return _database.InsertAsync(personevent);
            }
            else
            {
                return _database.UpdateAsync(personevent);
            }
        }
    }
}
