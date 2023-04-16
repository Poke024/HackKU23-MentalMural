using MentalMural.Server.Database.Data;
using Microsoft.EntityFrameworkCore;
using MentalMural.Shared;

namespace MentalMural.Server.Database
{
    public class JournalEntryCRUD
    {
        private JournalEntryDataContext _journalEntryDataContext;
        public JournalEntryCRUD(JournalEntryDataContext context)
        {
            this._journalEntryDataContext = context;
        }
        // CREATE
        public async Task<JournalEntryData> CreateNewJournalEntryAsync(JournalEntryData journalEntryData)
        {
            try
            {
                _journalEntryDataContext.JournalEntries.Add(journalEntryData);
                await _journalEntryDataContext.SaveChangesAsync();

            } 
            catch (Exception)
            {
                throw;
            }
            return journalEntryData;
        }

        public async Task<UserData> CreateNewUserAsync(UserData userData)
        {
            try
            {
                _journalEntryDataContext.UserInfo.Add(userData);
                await _journalEntryDataContext.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
            return userData;
        }

        // READ
        public async Task<List<JournalEntryData>> ReadJournalEntries()
        {
            return await _journalEntryDataContext.JournalEntries.ToListAsync();
        }

        public async Task<List<UserData>> ReadUserData()
        {
            return await _journalEntryDataContext.UserInfo.ToListAsync();
        }

        // UPDATE
        public async Task<JournalEntryData> UpdateJournalEntry(JournalEntryData journalEntryData)
        {
            try
            {
                var entryExist = _journalEntryDataContext.JournalEntries.FirstOrDefault(p => p.Id == journalEntryData.Id);
                if (entryExist != null)
                {
                    _journalEntryDataContext.Update(journalEntryData);
                    await _journalEntryDataContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return journalEntryData;
        }
        // DELETE
        public async Task DeleteJournalEntry(JournalEntryData journalEntryData)
        {
            try
            {
                _journalEntryDataContext.JournalEntries.Remove(journalEntryData);
                await _journalEntryDataContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
