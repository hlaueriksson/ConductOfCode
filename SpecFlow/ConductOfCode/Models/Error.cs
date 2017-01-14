using System;

namespace ConductOfCode.Models
{
    public class Error
    {
        public string Message { get; set; }

        public Error(Exception exception)
        {
            Message = exception.Message;
        }

        public Error(string message)
        {
            Message = message;
        }
    }
}