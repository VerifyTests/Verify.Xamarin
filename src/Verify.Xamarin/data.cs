using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace VerifyTests
{
    public struct ControlData
    {
        public IApp App { get; }
        public AppResult Result { get; }

        public ControlData(IApp app, AppResult result)
        {
            App = app;
            Result = result;
        }
    }
}