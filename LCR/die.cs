using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCR
{
    public class Die
    {
        private List<string> _Faces = new List<String>() { "Left", "Center", "Right", "None", "None", "None" }; 
        
        public List<String> Faces { get { return _Faces; } set { _Faces = value; } }

        public List<string> RollDie(int timesRolled)
        {
            Random random = new Random();
            List<string> dieResults = new List<string>();
            for (int i = 0; i < timesRolled; i++)
            {
                int dieResult = random.Next(0, 6);
                Console.WriteLine("Dieresult: " + dieResult + " " + i);
                dieResults.Add(this.Faces[dieResult]);
            }
            return dieResults;
        }
    }
}