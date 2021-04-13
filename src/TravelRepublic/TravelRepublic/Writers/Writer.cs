using System.Collections.Generic;
using TravelRepublic.Models;
using TravelRepublic.Wrapper;

namespace TravelRepublic.Writers
{
    public class Writer : IWriter
    {
        private readonly IWrapper _wrapper;
        public readonly string DateFormat = "yyyy-MMM-dd HH:mm:ss";

        public Writer(IWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public void Write(IList<Flight> flights)
        {
            int flightCount = 1;

            foreach (var flight in flights)
            {
                int segmentCount = 1;
                this._wrapper.WriteLine($"Flight-{flightCount:00}");
                this._wrapper.WriteLine("---------");
                this._wrapper.WriteLine();
                foreach (var segment in flight.Segments)
                {
                    this._wrapper.Write($"Segment-{segmentCount:00}: ");
                    this._wrapper.Write(segment.DepartureDate.ToString(this.DateFormat));
                    this._wrapper.WriteLine(" - " + segment.ArrivalDate.ToString(this.DateFormat));

                    segmentCount++;
                }

                this._wrapper.WriteLine();
                this._wrapper.WriteLine();
                flightCount++;
            }
        }
    }
}
