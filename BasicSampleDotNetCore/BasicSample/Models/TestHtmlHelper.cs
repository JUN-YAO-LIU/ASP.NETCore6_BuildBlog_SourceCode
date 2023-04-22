using Microsoft.AspNetCore.Mvc.Rendering;

namespace BasicSample.Models
{
    public class TestHtmlHelper
    {
        /// <summary>
        /// ValidationMessage
        /// </summary>
        public string TestValidationMessage { get; set; } = string.Empty;

        /// <summary>
        /// DisplayName
        /// </summary>
        public string TestDisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Label
        /// </summary>
        public string TestLabel { get; set; } = string.Empty;

        /// <summary>
        /// TextBox
        /// </summary>
        public string TestBox { get; set; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        public string TestPassword { get; set; } = string.Empty;

        /// <summary>
        /// CheckBox
        /// </summary>
        public bool TestCheckBox { get; set; }

        /// <summary>
        /// RadioButton
        /// </summary>
        public string TestRadioButton { get; set; } = string.Empty;

        /// <summary>
        /// DropDownList
        /// </summary>
        public string TestDropDownList { get; set; } = string.Empty;

        /// <summary>
        /// TextArea
        /// </summary>
        public string TestTextArea { get; set; } = string.Empty;

        /// <summary>
        /// Editor
        /// </summary>
        public string TestEditor { get; set; } = string.Empty;

        /// <summary>
        /// Hidden
        /// </summary>
        public string TestHidden { get; set; } = string.Empty;
    }
}