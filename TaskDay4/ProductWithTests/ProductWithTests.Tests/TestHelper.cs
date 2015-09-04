﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProductWithTests.Tests {
    static class TestHelper {
        public static IList<ValidationResult> Validate(object modelToValidate) {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(modelToValidate);
            Validator.TryValidateObject(modelToValidate, validationContext, results, true);
            return results;
        }
    }
}
