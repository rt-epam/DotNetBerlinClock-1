namespace BerlinClock.Validation.Errors
{
    public class ArgumentOutOfRangeError : IValidationError
    {
        private readonly int minValue;
        private readonly int maxValue;

        public ArgumentOutOfRangeError(string fieldName, int minValue, int maxValue)
        {
            FieldName = fieldName;
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public string FieldName { get; private set; }
        public string Message { get => $"The value should be between {minValue} and {maxValue}"; }
    }
}
