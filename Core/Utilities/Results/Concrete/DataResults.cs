using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class DataResults<T> : Result, IDataResult<T>
    {
        public DataResults(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResults(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; }

     
    }
}
