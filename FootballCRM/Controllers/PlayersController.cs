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
    public class PlayersController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public PlayersController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            var players = await _repository.Player.GetAll();

            var playerList = players
               .Select(x => new PlayerListModel
               {
                   PlayerId = x.PlayerId,
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   Number = x.Number,
                   Position = x.Position,
                   Team = x.TeamNavigation.Name

               });

            return Ok(playerList);
        }

        [HttpGet("{team}")]
        public async Task<ActionResult<IEnumerable<PlayerListModel>>> GetPlayersByTeam(string team)
        {
            var players = await _repository.Player.GetAll();

            var playerList = players
                .Where(x => x.TeamNavigation.Name.Equals(team))
                .Select(x => new PlayerListModel
                {
                    PlayerId = x.PlayerId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Number = x.Number,
                    Position = x.Position,
                    Team = x.TeamNavigation.Name

                });


            return Ok(playerList);
        }

        // GET: api/Players/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _repository.Player.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.PlayerId)
            {
                return BadRequest();
            }

            await _repository.Player.Update(player);

            return NoContent();
        }

        // POST: api/Players
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(PlayerFormModel playerFormModel)
        {
            var player = new Player
            {
                Number = playerFormModel.Number,
                FirstName = playerFormModel.FirstName,
                LastName = playerFormModel.LastName,
                Position = playerFormModel.Position,
                TeamId = playerFormModel.TeamId
            };

            await _repository.Player.Add(player);

            return CreatedAtAction("GetPlayer", new { id = player.PlayerId }, player);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Player>> DeletePlayer(int id)
        {
            var player = await _repository.Player.Delete(id);
            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

    }
}
