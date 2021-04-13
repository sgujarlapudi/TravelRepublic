using System.Collections.Generic;
using System.Linq;
using TravelRepublic.Filters;
using TravelRepublic.Models;

namespace TravelRepublic.Services
{
    public class FlightSelector
    {
        private readonly IList<IFlightFilter> _flightFilters;

        public FlightSelector(IList<IFlightFilter> flightFilters)
        {
            this._flightFilters = flightFilters;
        }

        public IList<Flight> Select(IList<Flight> flights)
        {
            var filteredFlights = flights.ToList();

            filteredFlights
                .RemoveAll(flight => this._flightFilters.Any(filter => filter.Filter(flight)));

            return filteredFlights;
        }
    }
}
