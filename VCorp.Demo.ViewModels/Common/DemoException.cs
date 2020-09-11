using System;

namespace VCorp.Demo.ViewModels.Common
{
    public class DemoException : Exception
    {
        public DemoException()
        {
        }

        public DemoException(string message)
            : base(message)
        {
        }

        public DemoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
