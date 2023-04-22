using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BasicSample.Models
{
    public class CreateUser
    {
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}