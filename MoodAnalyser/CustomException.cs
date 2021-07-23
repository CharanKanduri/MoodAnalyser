using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    class CustomException : Exception
    {
        MyException Exception;
        public enum MyException
        {
            NULL_ARGUMENT, EMPTY_INPUT_MRSSAGE, CLASS_NOT_FOUND, CONSTRUCTOR_NOT_FOUND
        }

        public CustomException(MyException exception, string message) : base(message)
        {
            this.Exception = exception;
        }
    }
}
