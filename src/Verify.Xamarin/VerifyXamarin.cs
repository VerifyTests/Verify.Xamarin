
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace VerifyTests
{
    public static class VerifyXamarin
    {
        static VerifyXamarin()
        {
        }

        public static void Enable()
        {
            VerifierSettings.RegisterFileConverter<IApp>(AppToImage);
            VerifierSettings.RegisterFileConverter<AppResult>(AppResultToImage);
        }

        static ConversionResult AppToImage(IApp target, VerifySettings settings)
        {
            var screenshot = target.Screenshot("temp");
            if (screenshot == null)
            {
                throw new Exception("IApp.Screenshot() returned null. It is possible ConfigureApp.Android.EnableLocalScreenshots() was not called.");
            }
            var stream = new MemoryStream(File.ReadAllBytes(screenshot.FullName));
            screenshot.Delete();
            return new ConversionResult(
                null,
                new List<ConversionStream>
                {
                    new ConversionStream("png", stream)
                });
        }

        private static ConversionResult AppResultToImage(AppResult target, VerifySettings settings)
        {
            throw new System.NotImplementedException();
        }
    }
}