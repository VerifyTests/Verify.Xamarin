using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

static class XamarinExtensions
{
    public static Stream TakeScreenshot(this IApp target)
    {
        var screenshot = target.Screenshot(Guid.NewGuid().ToString());
        if (screenshot == null)
        {
            throw new Exception("IApp.Screenshot() returned null. It is possible ConfigureApp.Android.EnableLocalScreenshots() was not called.");
        }

        var stream = new MemoryStream(File.ReadAllBytes(screenshot.FullName));
        screenshot.Delete();
        return stream;
    }

    public static Stream TakeScreenshot(this IApp target, AppResult appResult)
    {
        using var screenshot = target.TakeScreenshot();
        Bitmap bitmap = new Bitmap(screenshot);
        var rect = appResult.Rect;
        var cropSize = new Rectangle((int) rect.X, (int) rect.Y, (int) rect.Width, (int) rect.Height);

        using Bitmap cropped = bitmap.Clone(cropSize, bitmap.PixelFormat);
        var outputStream = new MemoryStream();
        cropped.Save(outputStream, ImageFormat.Png);
        return outputStream;
    }
}