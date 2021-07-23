using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    public class MoodAnalyser
    {
        string[] message;
        //Parameterised Constructor
        public MoodAnalyser(string[] message)
        {
            this.message = message;
        }

        public string ReturnMessage()
        {
            if (message.Contains("sad"))
            {
                return "Sad";
            }
            else
            {
                return "Happy";
            }
        }
    }
}
