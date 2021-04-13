using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRepublic.Wrapper
{
    public interface IWrapper
    {
        void WriteLine(string value);
        void WriteLine();
        void Write(string value);
    }
}
