using Microsoft.AspNetCore.Mvc;
using PhilosophersApi.Data;
using PhilosophersApi.Models;

namespace PhilosophersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly QuoteRepository _repository;

        public QuotesController(QuoteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuotes()
        {
            var quotes = await _repository.GetAllAsync();
            return Ok(quotes);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> GetQuoteById(string id)
        {
            var quote = await _repository.GetByIdAsync(id);
            if (quote == null) return NotFound();
            return Ok(quote);
        }

        [HttpGet("philosopher/{philosopher}")]
        public async Task<IActionResult> GetQuotesByPhilosopher(string philosopher)
        {
            var quotes = await _repository.GetByPhilosopherAsync(philosopher);
            return Ok(quotes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuote([FromBody] Quote quote)
        {
            if (string.IsNullOrWhiteSpace(quote.Philosopher) || string.IsNullOrWhiteSpace(quote.Text))
                return BadRequest("Philosopher and Text are required.");

            await _repository.CreateAsync(quote);
            return CreatedAtAction(nameof(GetQuoteById), new { id = quote.Id }, quote);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateQuote(string id, [FromBody] Quote quote)
        {
            var existingQuote = await _repository.GetByIdAsync(id);
            if (existingQuote == null) return NotFound();

            await _repository.UpdateAsync(id, quote);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteQuote(string id)
        {
            var quote = await _repository.GetByIdAsync(id);
            if (quote == null) return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
