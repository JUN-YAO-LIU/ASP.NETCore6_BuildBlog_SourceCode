using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace BasicSample.Models
{
    public class TestDataTypeHtmlHelper
    {
        public string TestString { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        public string TestPassword { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        public string TestEmail { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public string TestDate { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        public string TestDateTime { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        public int TestCurrency { get; set; }

        [DataType(DataType.MultilineText)]
        public string TestMultilineText { get; set; } = string.Empty;

        [DataType(DataType.Url)]
        public string TestUrl { get; set; } = string.Empty;
    }
}