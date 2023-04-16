using MentalMural.Server.Database;
using MentalMural.Server.Database.Data;
using MentalMural.Shared;

using Microsoft.AspNetCore.Mvc;

namespace MentalMural.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class JournalEntryController : ControllerBase
	{
		private readonly JournalEntryCRUD _crud;

		private readonly ILogger<JournalEntryController> _logger;

		public JournalEntryController(ILogger<JournalEntryController> logger, JournalEntryCRUD crud)
		{
			_logger = logger;
			_crud = crud;
		}

		[HttpGet]
        [Route("GetEntries")]
		public async Task<List<JournalEntryData>> Get()
        {
			return await _crud.ReadJournalEntries();
        }

        [HttpDelete]
		[Route("DeleteEntry/{id}")]
		public async Task Delete(int id)
        {
			JournalEntryData journalEntryData = (await _crud.ReadJournalEntries()).FirstOrDefault(p => p.Id == id);
			await _crud.DeleteJournalEntry(journalEntryData);
        }

        [HttpPost]
		[Route("AddEntry")]
		public async Task Add(JournalEntryData journalEntryData)
        {
			await _crud.CreateNewJournalEntryAsync(journalEntryData);
        }

        [HttpPatch]
		public async Task Update(JournalEntryData journalEntryData)
        {
			await _crud.UpdateJournalEntry(journalEntryData);
        }
	}
}