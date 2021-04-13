using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using TravelRepublic.Filters;
using TravelRepublic.Models;
using Xunit;

namespace TravelRepublicUnitTests.FilterTests
{
    public class SpendMoreThan2HoursOnGroundFilterTests
    {
         DateTime _currentDate= DateTime.Now;
        private IFlightFilter _flightFilter= new SpendMoreThan2HoursFilter();


        [Fact]
        public void ShouldBeTrueForDepatureBeforeCurrentDate()
        {
            var flight = this.GetFlightWithMoreThan2HoursOnTheGround();

            bool result = this._flightFilter.Filter(flight);

            result.ShouldBe(true);
        }

        [Fact]
        public void ShouldBeFalseForDepartureAfterCurrentDate()
        {
            var flight = this.GetFlightWithLessThan2HoursOnTheGround();

            bool result = this._flightFilter.Filter(flight);

           result.ShouldBe(false);

        }
        private Flight GetFlightWithMoreThan2HoursOnTheGround()
        {
            return new Flight
            {
                Segments = new List<Segment>
                {
                    new Segment
                    {
                        DepartureDate = this._currentDate.AddDays(-1),
                        ArrivalDate = this._currentDate.AddDays(1)
                    },
                    new Segment
                    {
                        DepartureDate = this._currentDate.AddDays(2),
                        ArrivalDate = this._currentDate.AddDays(3)
                    }
                }
            };
        }

        private Flight GetFlightWithLessThan2HoursOnTheGround()
        {
            return new Flight
            {
                Segments = new List<Segment>
                {
                    new Segment
                    {
                        DepartureDate = this._currentDate.AddDays(1),
                        ArrivalDate = this._currentDate.AddDays(2),
                    },
                    new Segment
                    {
                        DepartureDate = this._currentDate.AddDays(2).AddHours(1),
                        ArrivalDate = this._currentDate.AddDays(3),
                    }
                }
            };
        }
    }
}
