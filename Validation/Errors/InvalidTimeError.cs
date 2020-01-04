using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Validation.Errors
{
    public class InvalidTimeError : IValidationError
    {
        public string FieldName => null;

        public string Message => $"The given state does not represent a valid time";
    }
}
