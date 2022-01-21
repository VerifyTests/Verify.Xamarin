using Xamarin.UITest.Queries;

class AppResultConverter :
    WriteOnlyJsonConverter<AppResult>
{
    public override void Write(VerifyJsonWriter writer, AppResult result)
    {
        var rect = result.Rect;
        var rectString = $"w:{rect.Width} h:{rect.Height} x:{rect.X} y:{rect.Y}";
        var wrapper = new AppResultWrapper(result.Id, result.Label, result.Text, result.Class.Split('.').Last(), rectString);
        writer.Serialize(wrapper);
    }
}