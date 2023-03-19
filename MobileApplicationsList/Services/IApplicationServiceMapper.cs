using MobileApplicationsList.repository.DbModel;
using MobileApplicationsList.Services.ApiModel;

public interface IApplicationServiceMapper
{
     Task<List<IApplicationDetailsResponse>> MapApplicationDetails(List<AplicationDetails> applications);
    Task<ApplicationBase> MapCreateAppRequest(CreateApplicationRequest application);
}