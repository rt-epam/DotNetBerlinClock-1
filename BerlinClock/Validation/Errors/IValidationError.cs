namespace BerlinClock.Validation.Errors
{
    public interface IValidationError
    {
        string FieldName { get; }
        string Message { get; }
    }
}
