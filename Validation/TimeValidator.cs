using BerlinClock.Validation.Errors;

namespace BerlinClock.Validation
{
    public class TimeValidator : ValidatorBase<Time>
    {
        public override void Validate(Time time)
        {
            if (time.Hours < 0 || time.Hours > 24)
            {
                Errors.Add(new ArgumentOutOfRangeError(nameof(time.Hours), 0, 24));
            }

            if (time.Minutes < 0 || time.Minutes > 59)
            {
                Errors.Add(new ArgumentOutOfRangeError(nameof(time.Hours), 0, 59));
            }

            if (time.Seconds < 0 || time.Seconds > 59)
            {
                Errors.Add(new ArgumentOutOfRangeError(nameof(time.Hours), 0, 59));
            }

            if (time.Hours == 24 && (time.Minutes > 0 || time.Seconds > 0))
            {
                Errors.Add(new InvalidTimeError());
            }
        }
    }
}
