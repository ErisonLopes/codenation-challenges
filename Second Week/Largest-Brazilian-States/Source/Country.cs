using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Codenation.Challenge
{
    public class Country
    {
        public State[] Top10StatesByArea()
        {
            var brazilStates = ReadStates();
            State[] top10 = brazilStates.OrderByDescending(x => x.Area).Take(10).ToArray();

            return top10;
        }

        public List<State> ReadStates()
        {
            string filePath = $"{ Environment.CurrentDirectory }\\BrazilStates.json";
            string jsonStates = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<State>>(jsonStates);
        }
    }
}
