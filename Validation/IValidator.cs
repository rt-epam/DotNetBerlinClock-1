using BerlinClock.Validation.Errors;
using System.Collections.Generic;

namespace BerlinClock.Validation
{
    public interface IValidator<T>
    {
        void Validate(T entity);
        List<IValidationError> Errors { get; }
        bool IsValid { get; }
    }
}
