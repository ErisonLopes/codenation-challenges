using System;
using System.Collections.Generic;
using System.Text;

namespace Source
{
    public class Team
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MainShirtColor { get; set; }
        public string SecondaryShirtColor { get; set; }
        public DateTime CreateDate { get; set; }

        public Team(long id, string name, string mainShirtColor, string secondaryShirtColor, DateTime createDate)
        {
            Id = id;
            Name = name;
            MainShirtColor = mainShirtColor;
            SecondaryShirtColor = secondaryShirtColor;
            CreateDate = createDate;
        }
    }
}
