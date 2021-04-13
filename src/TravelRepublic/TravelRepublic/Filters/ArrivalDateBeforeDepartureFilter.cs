using System.Linq;
using TravelRepublic.Models;

namespace TravelRepublic.Filters
{
    public class ArrivalDateBeforeDepartureFilter:IFlightFilter
    {
        public bool Filter(Flight flight)
        {
            return flight.Segments.Any(segment => segment.ArrivalDate < segment.DepartureDate);
        }
    }
}
