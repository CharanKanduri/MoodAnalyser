using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;

namespace MoodAnalyser
{
    class MoodAnalysisFactory
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
            Type type = typeof(MoodAnalyser);
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
    }
}
