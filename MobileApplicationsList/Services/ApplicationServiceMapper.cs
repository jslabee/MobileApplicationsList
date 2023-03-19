using MobileApplicationsList.repository.DbModel;
using MobileApplicationsList.Services.ApiModel;

public class ApplicationServiceMapper : IApplicationServiceMapper
{

    public async Task<List<IApplicationDetailsResponse>> MapApplicationDetails(List<AplicationDetails> applications)
    {
        List<IApplicationDetailsResponse> applicationDetailsList = new List<IApplicationDetailsResponse>();

        foreach (var item in applications)
        {
            if (item.Type.Equals(ApplicationType.Android))
            {
                var androidApplicationDetailsResponse = new AndroidApplicationDetailsResponse
                {
                    Id = item.Id,
                    Score = item.Score,
                    Ratings = item.Ratings,
                    ApplicationStoreUrl = item.ApplicationStoreUrl,
                    Type = item.Type.ToString()
                };
                applicationDetailsList.Add(androidApplicationDetailsResponse);
            }
            if (item.Type.Equals(ApplicationType.Ios))
            {
                var iosApplicationDetailsResponse = new IosApplicationDetailsResponse
                {
                    Id = item.Id,
                    Score = item.Score,
                    Ratings = item.Ratings,
                    Size = item.Size,
                    ApplicationStoreUrl = item.ApplicationStoreUrl,
                    Type = item.Type.ToString()
                };
                applicationDetailsList.Add(iosApplicationDetailsResponse);
            }
        }

        return applicationDetailsList;
    }

  
    

    public async Task<ApplicationBase> MapCreateAppRequest(CreateApplicationRequest application)
    {
         var baseApp = new ApplicationBase
        {
            Name = application.Name,
            Image = application.Image,
            platformSpecific = new List<AplicationDetails>()   
        };
        if (!string.IsNullOrWhiteSpace(application.Android_store))
        {
            baseApp.platformSpecific.Add(new AplicationDetails
            {
                ApplicationStoreUrl = application.Android_store,
                Type = ApplicationType.Android,
                DateAdded = DateTime.UtcNow,
                Score = application.Score,
                Ratings = application.Ratings
            });

        }
        if (!string.IsNullOrWhiteSpace(application.Ios_store))
        {

            baseApp.platformSpecific.Add(new AplicationDetails
            {
                ApplicationStoreUrl = application.Ios_store,
                Type = ApplicationType.Ios,
                DateAdded = DateTime.UtcNow,
                Score = application.Score,
                Ratings = application.Ratings,
                Size = application.Size
            });

        }
      

        return baseApp;
    }
}













