using Volo.Abp.Application.Services;
using WavePlatform.Localization;

namespace WavePlatform.Services;

/* Inherit your application services from this class. */
public abstract class WavePlatformAppService : ApplicationService
{
    protected WavePlatformAppService()
    {
        LocalizationResource = typeof(WavePlatformResource);
    }
}