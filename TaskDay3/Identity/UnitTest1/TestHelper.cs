using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest1 {
    static class TestHelper {
        public static IList<ValidationResult> Validate(object modelToValidate) {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(modelToValidate);
            Validator.TryValidateObject(modelToValidate, validationContext, results, true);
            return results;
        }
    }
}
