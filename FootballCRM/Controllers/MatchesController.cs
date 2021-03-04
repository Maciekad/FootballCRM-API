using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Contracts;

namespace Entities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public MatchesController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // GET: api/Matches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatches()
        {
            var matches = await _repository.Match.GetAll();
            var matchesList = matches.Select(x =>
            new MatchListModel
            {
                MatchId = x.MatchId,
                Date = x.Date,
                EndDate = x.EndDate,
                Score = x.Score,
                Stadium = x.Stadium,
                HomeTeam = x.HomeTeamNavigation.Name,
                AwayTeam = x.AwayTeamNavigation.Name     
            });
            return Ok(matchesList);
        }

        // GET: api/Matches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetMatch(int id)
        {
            var match = await _repository.Match.Get(id);

            if (match == null)
            {
                return NotFound();
            }

            return match;
        }

        // PUT: api/Matches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch(int id, Match match)
        {
            if (id != match.MatchId)
            {
                return BadRequest();
            }

            await _repository.Match.Update(match);

            return NoContent();
        }

        // POST: api/Matches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(MatchFormModel matchFormModel)
        {
            var match = new Match
            {
                Date = matchFormModel.StartDate,
                EndDate = matchFormModel.EndDate,
                Score = matchFormModel.Score,
                Stadium = matchFormModel.Stadium,
                HomeTeamId = matchFormModel.HomeTeamId,
                AwayTeamId = matchFormModel.AwayTeamId
            };

            await _repository.Match.Add(match);

            return CreatedAtAction("GetMatch", new { id = match.MatchId }, match);
        }

        // DELETE: api/Matches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Match>> DeleteMatch(int id)
        {
            var match = await _repository.Match.Delete(id);
            if (match == null)
            {
                return NotFound();
            }

            return match;
        }

        
    }
}
