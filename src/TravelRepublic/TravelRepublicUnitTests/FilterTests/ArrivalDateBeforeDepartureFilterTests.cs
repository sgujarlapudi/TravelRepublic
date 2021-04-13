using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using TravelRepublic.Filters;
using TravelRepublic.Models;
using Xunit;

namespace TravelRepublicUnitTests.FilterTests
{
    public class ArrivalDateBeforeDepartureFilterTests
    {
        private readonly DateTime _currentDate= DateTime.Now;
        readonly IFlightFilter _flightFilter = new ArrivalDateBeforeDepartureFilter();

     
        [Fact]
        public void ShouldBeTrueForArrivalDateBeforeDepartureDate()
        {
            //Arrange
            var flight = this.GetFlightWithArrivalDateBeforeDepartureDate();
            //act
            bool result = this._flightFilter.Filter(flight);
            //Assert
            result.ShouldBe(true);
        }

        private Flight GetFlightWithArrivalDateBeforeDepartureDate()
        {
            return new Flight
            {
                Segments = new List<Segment>
            {
                new Segment
                {
                    DepartureDate = this._currentDate.AddDays(2),
                    ArrivalDate = this._currentDate.AddDays(1)
                }
            }
            };
        }


    }
}
