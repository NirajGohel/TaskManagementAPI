using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Entities;
using TaskManagementAPI.Interface;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeam _teamRepository;

        public TeamController(ITeam teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Team>>> GetAllTeams()
        {
            var teams = await _teamRepository.GetAllTeams();

            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var teams = await _teamRepository.GetTeamById(id);

            if (teams.Id == 0)
            {
                return NotFound("Team not found.");
            }

            return Ok(teams);
        }

        [HttpPost]
        public async Task<ActionResult<Team>> AddTeam(Team team)
        {
            var newTeam = await _teamRepository.AddTeam(team);

            return CreatedAtAction("AddTeam", newTeam);
        }

        [HttpPut]
        public async Task<ActionResult<Team>> UpdateTeam(Team updatedTeam)
        {
            var newTeam = await _teamRepository.UpdateTeam(updatedTeam);

            return Ok(newTeam);
        }

        [HttpDelete]
        public async Task<ActionResult<Team>> DeleteTeam(int id)
        {
            var team = await _teamRepository.DeleteTeam(id);

            return Ok(team);
        }
    }
}
