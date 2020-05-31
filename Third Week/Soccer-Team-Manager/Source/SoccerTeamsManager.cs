using System;
using System.Collections.Generic;
using Codenation.Challenge.Exceptions;
using System.Linq;
using Source;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        public List<Team> Teams;
        public List<Player> Players;

        public SoccerTeamsManager()
        {
            Teams = new List<Team>();
            Players = new List<Player>();
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            if (Teams.Any(x => x.Id == id))
                throw new UniqueIdentifierException($"O time { name } já está cadastrado. ID: { id }");

            Teams.Add(new Team(id, name, mainShirtColor, secondaryShirtColor, createDate));
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            if (Players.Any(x => x.Id == id))
                throw new UniqueIdentifierException($"O jogador { name } já está cadastrado. ID: { id }");

            if (!Teams.Any(x => x.Id == teamId))
                throw new TeamNotFoundException($"O time { name } não foi encontrado. ID: { id }");

            Players.Add(new Player(id, name, birthDate, skillLevel, salary, teamId));
        }

        public void SetCaptain(long playerId)
        {
            if (!Players.Any(x => x.Id == playerId))
                throw new PlayerNotFoundException($"O jogador com o Id - { playerId } não foi encontrado.");

            int newCaptainIndex = Players.FindIndex(x => x.Id == playerId);
            long teamId = Players[newCaptainIndex].TeamId;

            var oldCaptain = Players.Where(x => x.TeamId == teamId && x.Capitain).FirstOrDefault();

            if (oldCaptain != null)
            {
                int oldCaptainIdIndex = Players.FindIndex(x => x.Id == oldCaptain.Id);

                Players[oldCaptainIdIndex].Capitain = false;
            }

            Players[newCaptainIndex].Capitain = true;
        }

        public long GetTeamCaptain(long teamId)
        {
            if (!Teams.Any(x => x.Id == teamId))
                throw new TeamNotFoundException($"O time com o Id - { teamId } não foi encontrado.");

            var captain = Players.Where(x => x.TeamId == teamId && x.Capitain).FirstOrDefault();
            if (captain == null)
                throw new CaptainNotFoundException($"O capitão do time - { teamId } não foi encontrado.");

            return captain.Id;
        }

        public string GetPlayerName(long playerId)
        {
            string playerName = Players.Where(x => x.Id == playerId).FirstOrDefault().Name;

            if (playerName == null)
                throw new PlayerNotFoundException($"O jogador com o Id - { playerId } não foi encontrado.");

            return playerName;
        }

        public string GetTeamName(long teamId)
        {
            string teamName = Teams.Where(x => x.Id == teamId).Select(x => x.Name).FirstOrDefault();

            if (teamName == null)
                throw new TeamNotFoundException($"O time com o Id - { teamId } não foi encontrado.");

            return teamName;
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            if (!Teams.Any(x => x.Id == teamId))
                throw new TeamNotFoundException($"O time com o Id - { teamId } não foi encontrado.");

            return Players
                    .Where(x => x.TeamId == teamId)
                    .OrderBy(x => x.Id)
                    .Select(x => x.Id)
                    .ToList();
        }

        public long GetBestTeamPlayer(long teamId)
        {
            if (!Teams.Any(x => x.Id == teamId))
                throw new TeamNotFoundException($"O time com o Id - { teamId } não foi encontrado.");

            return Players
                    .Where(p => p.TeamId == teamId)
                    .OrderByDescending(p => p.SkillLevel)
                    .Select(p => p.Id)
                    .FirstOrDefault();
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            if (!Teams.Any(x => x.Id == teamId))
                throw new TeamNotFoundException($"O time com o Id - { teamId } não foi encontrado.");

            return Players
                    .Where(x => x.TeamId == teamId)
                    .OrderBy(x => x.BirthDate)
                    .ThenBy(x => x.Id)
                    .FirstOrDefault().Id;
        }

        public List<long> GetTeams()
        {
            return Teams.OrderBy(x => x.Id).Select(x => x.Id).ToList();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            if (!Teams.Any(x => x.Id == teamId))
                throw new TeamNotFoundException($"O time com o Id - { teamId } não foi encontrado.");

            return Players
                    .Where(p => p.TeamId == teamId)
                    .OrderByDescending(p => p.Salary)
                    .ThenBy(p => p.Id)
                    .Select(p => p.Id)
                    .FirstOrDefault();
        }

        public decimal GetPlayerSalary(long playerId)
        {
            Player player = Players.Where(p => p.Id == playerId).FirstOrDefault();

            if (player == null)
                throw new PlayerNotFoundException($"O jogador com o Id - { playerId } não foi encontrado.");

            return player.Salary;
        }

        public List<long> GetTopPlayers(int top)
        {
            return Players
                    .OrderByDescending(p => p.SkillLevel)
                    .ThenBy(p => p.Id)
                    .Take(top)
                    .Select(p => p.Id)
                    .ToList();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            Team team = Teams.Where(x => x.Id == teamId).FirstOrDefault();

            if (team == null)
                throw new TeamNotFoundException($"Time da casa { teamId } não encontrado.");

            var visitorTeam = Teams.Where(x => x.Id == visitorTeamId).FirstOrDefault();

            if (visitorTeam == null)
                throw new TeamNotFoundException($"Time da visitante { teamId } não encontrado.");

            return team.MainShirtColor == visitorTeam.MainShirtColor ? visitorTeam.SecondaryShirtColor : visitorTeam.MainShirtColor;
        }
    }
}
