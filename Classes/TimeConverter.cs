using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private readonly ITimeParser timeParser;
        private readonly IBerlinClockConsoleSerializer consoleSerializer;

        public TimeConverter(ITimeParser timeParser, IBerlinClockConsoleSerializer consoleSerializer)
        {
            this.timeParser = timeParser ?? throw new ArgumentNullException(nameof(timeParser));
            this.consoleSerializer = consoleSerializer ?? throw new ArgumentNullException(nameof(consoleSerializer));
        }

        public string convertTime(string timeString)
        {
            var time = timeParser.Parse(timeString);
            var state = new BerlinClockState();
            return consoleSerializer.Serialize(state);
        }
    }
}
