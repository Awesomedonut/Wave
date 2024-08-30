using Microsoft.Extensions.Localization;
using WavePlatform.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace WavePlatform;

[Dependency(ReplaceServices = true)]
public class WavePlatformBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<WavePlatformResource> _localizer;

    public WavePlatformBrandingProvider(IStringLocalizer<WavePlatformResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}