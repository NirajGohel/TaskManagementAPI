using TaskManagementAPI.Entities;

namespace TaskManagementAPI.Interface
{
    public interface ITeam
    {
        Task<List<Team>> GetAllTeams();

        Task<Team> GetTeamById(int id);

        Task<Team> AddTeam(Team team);

        Task<Team> UpdateTeam(Team team);

        Task<Team> DeleteTeam(int id);
    }
}
