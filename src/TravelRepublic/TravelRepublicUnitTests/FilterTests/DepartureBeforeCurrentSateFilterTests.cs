using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using TravelRepublic.Filters;
using TravelRepublic.Models;
using Xunit;

namespace TravelRepublicUnitTests.FilterTests
{
    public class DepartureBeforeCurrentSateFilterTests
    {
        private readonly DateTime _currentDate= DateTime.Now;
        private readonly IFlightFilter _flightFilter= new DepartureBeforeCurrentDateFilter();

        [Fact]
        public void ShouldBeTrueForDepartureBeforeCurrentDate()
        {
          var flight = this.GetFlightWithDepartureBeforeCurrentDate();

            bool result = this._flightFilter.Filter(flight);

           result.ShouldBe(true);
        }

        [Fact]
        public void ShouldBeFalseForDepartureBeforeCurrentDate()
        {
            var flight = this.GetFlightWithDepartureDateAfterCurrentDate();

            bool result = this._flightFilter.Filter(flight);

            result.ShouldBe(false);
        }

        private Flight GetFlightWithDepartureBeforeCurrentDate()
        {
            return new Flight
            {
                Segments = new List<Segment>
                {
                    new Segment
                    {
                        DepartureDate = this._currentDate.AddDays(-1),
                        ArrivalDate = this._currentDate.AddDays(1)
                    }
                }
            };
        }

        private Flight GetFlightWithDepartureDateAfterCurrentDate()
        {
            return new Flight
            {
                Segments = new List<Segment>
                {
                    new Segment
                    {
                        DepartureDate = this._currentDate.AddDays(1),
                        ArrivalDate = this._currentDate.AddDays(2),
                    }
                }
            };
        }



    }
}
