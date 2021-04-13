using System.Collections.Generic;
using TravelRepublic.Filters;
using TravelRepublic.Models;
using TravelRepublic.Services;
using TravelRepublic.Writers;


namespace TravelRepublic
{
    public class Program
    {
        static void Main(string[] args)
        {
            var service = new FlightBuilder();
            IList<Flight> flights = service.GetFlights();
            var flightSelector = GetFlightSelector();

            var filteredFlights = flightSelector.Select(flights);

            var outputWriter = new Writer(new Wrapper.Wrapper());
            outputWriter.Write(filteredFlights);
        }

        private static FlightSelector GetFlightSelector()
        {
            return new FlightSelector(new List<IFlightFilter>
            {
                new DepartureBeforeCurrentDateFilter(),
                new ArrivalDateBeforeDepartureFilter(),
                new SpendMoreThan2HoursFilter()
            });
        }

    }
}
