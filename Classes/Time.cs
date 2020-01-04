namespace BerlinClock
{
    public class Time
    {
        public Time()
        {
            Set = new TimeFluentInterface(this);
        }

        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public TimeFluentInterface Set { get; set; }
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
