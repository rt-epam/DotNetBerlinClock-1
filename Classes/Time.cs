using System.Collections.Generic;
using System.Linq;

namespace BerlinClock
{
    public class Time
    {
        private readonly TimeValidator timeValidator;

        public Time()
        {
            timeValidator = new TimeValidator();
            Set = new TimeFluentInterface(this);
        }

        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public TimeFluentInterface Set { get; set; }

        public bool IsValid
        {
            get
            {
                timeValidator.Validate(this);
                return timeValidator.Errors.Any();
            }
        }
    }

    public class TimeValidator
    {
        public IList<ValidationError> Errors { get; } = new List<ValidationError>();

        public void Validate(Time time)
        {

        }
    }

    public class TimeFluentInterface
    {
        private readonly Time time;

        public TimeFluentInterface(Time time)
        {
            this.time = time;
        }

        public TimeFluentInterface Hours(int hours)
        {
            this.time.Hours = hours;
            return this;
        }

        public TimeFluentInterface Minutes(int minutes)
        {
            this.time.Minutes = minutes;
            return this;
        }

        public TimeFluentInterface Seconds(int seconds)
        {
            this.time.Seconds = seconds;
            return this;
        }
    }
}
