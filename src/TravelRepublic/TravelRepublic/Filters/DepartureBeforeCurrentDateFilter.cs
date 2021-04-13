using System;
using System.Linq;
using TravelRepublic.Models;

namespace TravelRepublic.Filters
{
    public class DepartureBeforeCurrentDateFilter:IFlightFilter
    {
        public bool Filter(Flight flight)
        {
            DateTime currentDate = DateTime.Now;

            return flight.Segments.Any(segment => segment.DepartureDate < currentDate);
        }
    }
}
