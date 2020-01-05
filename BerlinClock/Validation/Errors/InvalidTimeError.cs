namespace BerlinClock.Validation.Errors
{
    public class InvalidTimeError : IValidationError
    {
        public string FieldName => null;

        public string Message => "The given state does not represent a valid time";
    }
}
