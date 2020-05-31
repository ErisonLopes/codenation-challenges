namespace Codenation.Challenge
{
    public class State
    {
        public string Name { get; set; }

        public string Acronym { get; set; }

        public double Area { get; set; }

        public State(string name, string acronym)
        {
            this.Name = name;
            this.Acronym = acronym;
        }
    }

}
