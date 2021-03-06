using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Mood_Analyser
{
    public class MoodAnalysisFactory
    {
        public object CreatingObjectWithMethod(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Regex regex = new Regex(pattern);
            if (regex.Match(className).Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type classNameStore = assembly.GetType(className);
                    var obj = Activator.CreateInstance(classNameStore);
                    return obj;
                }
                catch
                {
                    throw new CustomException(CustomException.MyException.CLASS_NOT_FOUND, "Class does not exist");

                }

            }
            else
            {
                throw new CustomException(CustomException.MyException.CONSTRUCTOR_NOT_FOUND, "Class does not have such Constructor");
            }
        }

        public object CreatingParameterisedObjectWithMethod(string className, string constructorName, string[] message)
        {
            Type type = typeof(Mood_Analyser.MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                try
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string[]) });
                    object obj = constructorInfo.Invoke(new object[] { message });
                    return obj;
                }
                catch
                {
                    throw new CustomException(CustomException.MyException.CLASS_NOT_FOUND, "Class does not exist");

                }

            }
            else
            {
                throw new CustomException(CustomException.MyException.CONSTRUCTOR_NOT_FOUND, "Class does not have such Constructor");
            }
        }

        public string InvokeMethod(string methodname, string[] message)
        {
            try
            {
                MoodAnalysisFactory moodAnalyserFactory = new MoodAnalysisFactory();
                Type type = typeof(MoodAnalyser);
                object methodObject = moodAnalyserFactory.CreatingParameterisedObjectWithMethod("Mood_Analyser.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo methodInfo = type.GetMethod(methodname);
                string method = (string)methodInfo.Invoke(methodObject, null);
                return method;

            }
            catch (NullReferenceException)
            {
                throw new CustomException(CustomException.MyException.METHOD_NOT_FOUND, "No method found");
            }
        }
    }
}
