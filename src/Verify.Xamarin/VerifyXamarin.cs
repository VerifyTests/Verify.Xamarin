using System;
using System.Collections.Generic;
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

        static ConversionResult AppToImage(IApp target, VerifySettings settings)
        {
            var appResults = target.Query();

            var screenshot = target.TakeScreenshot();
            return new ConversionResult(
                appResults,
                new List<ConversionStream>
                {
                    new ConversionStream("png", screenshot)
                });
        }

        static ConversionResult AppResultToImage(ControlData target, VerifySettings settings)
        {
            var result = target.Result;
            var screenshot = target.App.TakeScreenshot(result);
            return new ConversionResult(
                result,
                new List<ConversionStream>
                {
                    new ConversionStream("png", screenshot)
                });
        }
    }
}