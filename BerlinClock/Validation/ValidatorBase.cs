using BerlinClock.Validation.Errors;
using System.Collections.Generic;
using System.Linq;

namespace BerlinClock.Validation
{
    public abstract class ValidatorBase<T> : IValidator<T>
    {
        public List<IValidationError> Errors { get; } = new List<IValidationError>();

        public bool IsValid
        {
            get { return !Errors.Any(); }
        }

        public abstract void Validate(T entity);
    }
}
