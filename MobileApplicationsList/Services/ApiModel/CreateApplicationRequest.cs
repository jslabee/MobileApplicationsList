

using System.ComponentModel.DataAnnotations;

namespace MobileApplicationsList.Services.ApiModel
{
    public class CreateApplicationRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        public string Android_store { get; set; }
        public string Ios_store { get; set; }
        public int Ratings { get; set; }
        public double Score { get; set; }
        public double Size { get; set; }
    }
}