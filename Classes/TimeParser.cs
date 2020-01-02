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
                result.Set.Hours(hours);
            }
            else
            {
                throw new ArgumentException(ArgumentExceptionMessage);
            }

            if (timeParts[1].Length > 0
                && timeParts[1].Length <= 2
                && int.TryParse(timeParts[1], out int minutes)
                && minutes >= 0
                && minutes < 60)
            {
                result.Set.Minutes(minutes);
            }
            else
            {
                throw new ArgumentException(ArgumentExceptionMessage);
            }

            if (timeParts[2].Length > 0
                && timeParts[2].Length <= 2
                && int.TryParse(timeParts[2], out int seconds)
                && seconds >= 0
                && seconds < 60)
            {
                result.Set.Seconds(seconds);
            }
            else
            {
                throw new ArgumentException(ArgumentExceptionMessage);
            }

            return result;
        }
    }
}
