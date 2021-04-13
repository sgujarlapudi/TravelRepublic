using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using TravelRepublic.Filters;
using TravelRepublic.Models;
using TravelRepublic.Services;
using Xunit;

namespace TravelRepublicUnitTests
{
    public class FlightSelectorTests
    {
        private readonly Mock<IFlightFilter> _filter1 = new Mock<IFlightFilter>();
        private readonly Mock<IFlightFilter> _filter2 = new Mock<IFlightFilter>();
        private FlightSelector _flightSelector;

      
        [Fact]
        public void ShouldOnlyReturnTheNotFilteredFlights()
        {
            _flightSelector = new FlightSelector(new List<IFlightFilter>
                { _filter1.Object, this._filter2.Object });
            IList<Flight> flights = this.GetTestFlights();

            var firstFilter = _filter1.SetupSequence
                (x => x.Filter(It.IsAny<Flight>())).Returns(true).Returns(false);
            var secondFilter = _filter2.Setup(x => x.Filter
                (It.IsAny<Flight>())).Returns(false);

            IList<Flight> selectedFlights = this._flightSelector.Select(flights);
            selectedFlights.Count.ShouldBe(1);
        }

        private IList<Flight> GetTestFlights()
        {
            var flight1 = new Flight
            {
                Segments = new List<Segment>
                {
                    new Segment
                    {
                        DepartureDate = DateTime.Today,
                        ArrivalDate = DateTime.Today.AddDays(1)
                    }
                }
            };

            var flight2 = new Flight
            {
                Segments = new List<Segment>
                {
                    new Segment
                    {
                        DepartureDate = DateTime.Today,
                        ArrivalDate = DateTime.Today.AddDays(3)
                    }
                }
            };


            return new List<Flight> {flight1, flight2};
        }
    }
}
