using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VerifyTests;
using VerifyNUnit;
using NUnit.Framework;
using Xamarin.UITest;

[TestFixture]
public class TheTests
{
    IApp app;

    #region ControlUsage

    [Test]
    public async Task ControlUsage()
    {
        var appResult = app.Query(x => x.Id("theText"))
            .Single();
        var data = new ControlData(app, appResult);
        await Verify(data);
    }

    #endregion

    #region AppUsage

    [Test]
    public async Task AppUsage()
    {
        await Verify(app);
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

        VerifyPhash.RegisterComparer("png", .9f);
    }
}
