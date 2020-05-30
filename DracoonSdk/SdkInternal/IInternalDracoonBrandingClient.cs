namespace Dracoon.Sdk.SdkInternal {
    internal interface IInternalDracoonBrandingClient : IInternalDracoonClientBase {
        DracoonBrandingImpl BrandingImpl { get; }
    }
}
