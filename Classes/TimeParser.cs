using BerlinClock.Validation;
using System;
using System.Text.RegularExpressions;

namespace BerlinClock
{
    internal class TimeParser : ITimeParser
    {
        private const string TimePattern = @"^(?<hours>\d{1,2}):(?<minutes>\d{2}):(?<seconds>\d{2})$";
        private const string IncorrectFormatMessage = "The given string is not a correct time";

        private readonly IValidator<Time> timeValidator;

        public TimeParser(IValidator<Time> timeValidator)
        {
            this.timeValidator = timeValidator ?? throw new ArgumentNullException(nameof(timeValidator));
        }

        public Time Parse(string timeString)
        {
            var match = Regex.Match(timeString, TimePattern);
            if (match.Success)
            {
                var time = new Time();
                time.Set
                    .Hours(int.Parse(match.Groups["hours"].Value))
                    .Minutes(int.Parse(match.Groups["minutes"].Value))
                    .Seconds(int.Parse(match.Groups["seconds"].Value));

                timeValidator.Validate(time);
                if (timeValidator.IsValid)
                {
                    return time;
                }
            }

            throw new ArgumentException(IncorrectFormatMessage);
        }
    }
}
