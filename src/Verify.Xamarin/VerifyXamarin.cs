using Xamarin.UITest;

namespace VerifyTests
{
    public static class VerifyXamarin
    {
        static VerifyXamarin()
        {
            VerifierSettings.ModifySerialization(settings =>
            {
                settings.AddExtraSettings(serializerSettings =>
                {
                    var converters = serializerSettings.Converters;
                    converters.Add(new AppResultConverter());
                });
            });
        }

        public static void Enable()
        {
            VerifierSettings.RegisterFileConverter<IApp>(AppToImage);
            VerifierSettings.RegisterFileConverter<ControlData>(AppResultToImage);
        }

        static ConversionResult AppToImage(IApp target, IReadOnlyDictionary<string, object> context)
        {
            var appResults = target.Query();

            var screenshot = target.TakeScreenshot();
            return new ConversionResult(
                appResults,
                new List<Target>
                {
                    new Target("png", screenshot, null)
                });
        }

        static ConversionResult AppResultToImage(ControlData target, IReadOnlyDictionary<string, object> context)
        {
            var result = target.Result;
            var screenshot = target.App.TakeScreenshot(result);
            return new ConversionResult(
                result,
                new List<Target>
                {
                    new Target("png", screenshot, null)
                });
        }
    }
}