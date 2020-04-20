using Dracoon.Sdk.Model;

namespace Dracoon.Sdk {
    public interface IBranding {

        CacheableBrandingResponse GetBranding();

        SoftwareVersionData GetVersion();
    }
}
