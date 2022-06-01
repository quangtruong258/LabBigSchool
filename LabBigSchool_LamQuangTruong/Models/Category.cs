using System.ComponentModel.DataAnnotations;

namespace LabBigSchool_LamQuangTruong.Models
{
    public class Category
    {
        public byte ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


    }
}