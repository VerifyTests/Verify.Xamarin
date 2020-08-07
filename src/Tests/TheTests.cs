using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VerifyTests;
using VerifyNUnit;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.iOS;

[TestFixture]
public class TheTests
{
    AndroidApp app;

    #region ElementUsage

    [Test]
    public async Task ElementUsage()
    {
        var element = app.WaitForElement(query => query.Marked("second"))!;
        await Verifier.Verify(element.Single());
    }

    #endregion

    #region AppUsage

    [Test]
    public async Task AppUsage()
    {
        await Verifier.Verify(app);
    }

    #endregion

    public TheTests()
    {
        var directory = AppDomain.CurrentDomain.BaseDirectory;
        var apkPath = Path.GetFullPath(Path.Combine(directory, "../../../../SampleXamarin/bin/Debug/SampleXamarin.SampleXamarin.apk"));

        #region AppSetup

        app = ConfigureApp
            .Android
            .EnableLocalScreenshots()
            .ApkFile(apkPath)
            .StartApp();

        #endregion
    }

    static TheTests()
    {
        #region Enable

        VerifyXamarin.Enable();

        #endregion

        VerifierSettings.UniqueForRuntime();
        VerifyPhash.RegisterComparer("png", .9f);
    }
}