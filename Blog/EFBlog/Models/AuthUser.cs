using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFBlog.Models
{
    public class AuthUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Account { get; set; } = string.Empty;

        public string Pwd { get; set; } = string.Empty;
    }
}