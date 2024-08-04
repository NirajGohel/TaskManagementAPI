using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Entities;
using TaskManagementAPI.Interface;

namespace TaskManagementAPI.Repositories
{
    public class TeamRepository : ITeam
    {
        private readonly DataContext _context;

        public TeamRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Team> AddTeam(Team team)
        {
            var res = _context.Teams.AddAsync(team);
            if (res.IsCompleted)
            {
                await _context.SaveChangesAsync();
            }

            return team;
        }

        public async Task<Team> DeleteTeam(int id)
        {
            var dbTeam = await _context.Teams.FindAsync(id);

            if (dbTeam == null)
            {
                return new Team();
            }

            _context.Teams.Remove(dbTeam);
            await _context.SaveChangesAsync();

            return dbTeam;
        }

        public async Task<List<Team>> GetAllTeams()
        {
            var teams = await _context.Teams.ToListAsync();
            return teams;
        }

        public async Task<Team> GetTeamById(int id)
        {
            var team = await _context.Teams.FindAsync(id);

            if (team == null)
            {
                return new Team();
            }

            return team;
        }

        public async Task<Team> UpdateTeam(Team updatedTeam)
        {
            var dbTeam = await _context.Teams.FindAsync(updatedTeam.Id);

            if (dbTeam == null)
            {
                return new Team();
            }

            dbTeam.Name = updatedTeam.Name;
            dbTeam.ManagerId = updatedTeam.ManagerId;

            await _context.SaveChangesAsync();
            return dbTeam;
        }
    }
}
