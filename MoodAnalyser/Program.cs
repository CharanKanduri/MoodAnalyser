using System;

namespace MoodAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get input statement from user
            Console.WriteLine("Welcome To Mood Analyser!");
            string[] message = Console.ReadLine().ToLower().Split(" ");
            MoodAnalyser setmood = new MoodAnalyser(message);
            Console.WriteLine("Mood is: {0}", setmood.ReturnMessage());
        }
    }
}
