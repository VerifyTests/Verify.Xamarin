using System.Linq;
using Newtonsoft.Json;
using VerifyTests;
using Xamarin.UITest.Queries;

class AppResultConverter :
    WriteOnlyJsonConverter<AppResult>
{
    public override void WriteJson(JsonWriter writer, AppResult? result, JsonSerializer serializer)
    {
        if (result == null)
        {
            return;
        }

        var rect = result.Rect;
        var rectString = $"w:{rect.Width} h:{rect.Height} x:{rect.X} y:{rect.Y}";
        var wrapper = new AppResultWrapper(result.Id, result.Label, result.Text, result.Class.Split('.').Last(), rectString);
        serializer.Serialize(writer, wrapper);
    }
}