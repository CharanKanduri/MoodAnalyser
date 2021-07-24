﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mood_Analyser
{
    public class MoodAnalyser
    {
        string[] message;
        //Default constructor
        public MoodAnalyser()
        {
            Console.WriteLine("This is default constructor");
        }
        //Parameterised Constructor
        public MoodAnalyser(string[] message)
        {
            this.message = message;
        }

        public string ReturnMessage()
        {
            try
            {
                if (message.Contains(string.Empty))
                {
                    throw new CustomException(CustomException.MyException.EMPTY_INPUT_MRSSAGE, "Mood should not be Empty");
                }
                if (message.Contains(null))
                {
                    throw new CustomException(CustomException.MyException.NULL_ARGUMENT, "Mood should not be Null");
                }
                if (message.Contains("sad"))
                {
                    return "Sad";
                }
                else
                {
                    return "Happy";
                }
            }
            catch (ArgumentNullException ex)
            {

                return "Happy";
            }
        }
    }
}
