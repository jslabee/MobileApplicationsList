

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace MobileApplicationsList.Services.ApiModel
{
    public class IosApplicationDetailsResponse : IApplicationDetailsResponse
    {
        public int Id { get; set; }
        public double Score { get; set; }
        public int Ratings { get; set; }
        public double Size { get; set; }
        public string ApplicationStoreUrl { get; set; }
        public string Type { get; set; }
    }

    public class AndroidApplicationDetailsResponse : IApplicationDetailsResponse
    {
        public int Id { get; set; }
        public double Score { get; set; }
        public int Ratings { get; set; }

        public string ApplicationStoreUrl { get; set; }
        public string Type { get; set; }

    }
    public interface IApplicationDetailsResponse
    {
        int Id { get; set; }
        double Score { get; set; }
        int Ratings { get; set; }
        string ApplicationStoreUrl { get; set; }
        string Type { get; set; }
    }
}
