using System;
using System.Collections.Generic;
using System.Text;
using TravelRepublic.Models;

namespace TravelRepublic.Filters
{
    public interface IFlightFilter
    {
        bool Filter(Flight flight);
    }
}
