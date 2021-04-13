using System;
using System.Collections.Generic;
using System.Text;
using TravelRepublic.Models;

namespace TravelRepublic.Writers
{
    public interface IWriter
    {
        public void Write(IList<Flight> flights);
    }
}
