using System;

namespace BerlinClock
{
    internal class TimeParser : ITimeParser
    {
        private const char TimeSeparator = ':';

        private const string ArgumentExceptionMessage = "The given string is not a correct time";

        public Time Parse(string timeString)
        {
            var result = new Time();

            var timeParts = timeString.Split(TimeSeparator);
            if (timeParts.Length != 3)
            {
                throw new ArgumentException(ArgumentExceptionMessage);
            }

            if (timeParts[0].Length > 0
                && timeParts[0].Length <= 2
                && int.TryParse(timeParts[0], out int hours)
                && hours >= 0
                && hours <= 23)
            {
                result.Hours = hours;
            }
            else
            {
                throw new ArgumentException(ArgumentExceptionMessage);
            }

            return result;
        }
    }
}
