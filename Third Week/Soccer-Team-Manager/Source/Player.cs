using System;
using System.Collections.Generic;
using System.Text;

namespace Source
{
    public class Player
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int SkillLevel { get; set; }
        public decimal Salary { get; set; }
        public long TeamId { get; set; }
        public bool Capitain { get; set; }


        public Player(long id, string name, DateTime birthDate, int skillLevel, decimal salary, long teamId)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            SkillLevel = skillLevel;
            Salary = salary;
            TeamId = teamId;
        }
    }
}
