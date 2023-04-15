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
		private static readonly string[] Summaries = new[]
		{ "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

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
		// how do i route a uri with params or otherwise how do i avoid using this
		public async Task Delete([FromQuery]int id)
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

		/*public IEnumerable<WeatherForecast> Get()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
		}*/
	}
}