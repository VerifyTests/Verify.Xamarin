//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using VerifyTests;
//using VerifyNUnit;
//using NUnit.Framework;

//[TestFixture]
//public class TheTests :
//    IDisposable
//{
//    #region ElementUsage
//    [Test]
//    public async Task ElementUsage()
//    {
//        var element = app.WaitForElement(query => query.Marked("second"))!;
//        await Verifier.Verify(element.Single());
//    }
//    #endregion

//    public TheTests()
//    {
//        #region UnoAppSetup
//        var environment = AppInitializer.TestEnvironment;
//        environment.WebAssemblyDefaultUri = "http://localhost:57416";
//        environment.CurrentPlatform = Platform.Browser;

//        app = AppInitializer.AttachToApp();
//        #endregion
//    }

//    static TheTests()
//    {
//        #region Enable
//        VerifyUno.Enable();
//        #endregion
//        VerifierSettings.UniqueForRuntime();
//        VerifyPhash.RegisterComparer("png", .99f);
//    }

//    public void Dispose()
//    {
//        app.Dispose();
//    }
//}