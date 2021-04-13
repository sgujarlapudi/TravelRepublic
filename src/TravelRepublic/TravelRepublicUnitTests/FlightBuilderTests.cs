using Shouldly;
using System.Collections.Generic;
using TravelRepublic.Models;
using TravelRepublic.Services;
using Xunit;

namespace TravelRepublicUnitTests
{
    public class FlightBuilderTests
    {
        private readonly int _totalNumberOfExpectedFlights = 6;
        private readonly FlightBuilder _flightBuilder = new FlightBuilder();
        [Fact]
        public void FlightBuilder_ShouldReturnExpectedFlights()
        {
            IList<Flight> flights = this._flightBuilder.GetFlights();
            var result = flights.Count;
            result.ShouldBe(_totalNumberOfExpectedFlights);
        }
    }
}
