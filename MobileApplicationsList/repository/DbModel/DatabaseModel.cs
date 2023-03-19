

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MobileApplicationsList.repository.DbModel
{

    [Table("aplicationdetails")]
    public class AplicationDetails
    {
        [Key]
        public int Id { get; set; }
        public double Score { get; set; }
        public int Ratings { get; set; }
        public double Size { get; set; }
        public string ApplicationStoreUrl { get; set; }
        public ApplicationType Type { get; set; }

        public DateTime DateAdded { get; set; }

    }
    public enum ApplicationType
    {

        Ios,

        Android
    }

    [Table("applicationbase")]
    public class ApplicationBase
    {
        [Key]

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }

        public List<AplicationDetails> platformSpecific { get; set; }
    }
}
