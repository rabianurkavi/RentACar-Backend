using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data,bool success,string message):base(data,false,message)
        {

        }
        public ErrorDataResult(T data,bool succes):base(data,false)
        {

        }
        public ErrorDataResult(string message):base(message)
        {

        }
    }
}
