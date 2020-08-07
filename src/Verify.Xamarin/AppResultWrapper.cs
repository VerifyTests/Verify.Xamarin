struct AppResultWrapper
{
    public string Id { get; }
    public string Label { get; }
    public string Text { get; }
    public string Class { get; }
    public string Rect { get; }

    public AppResultWrapper(string id, string label, string text, string @class, string rect)
    {
        Id = id;
        Label = label;
        Text = text;
        Class = @class;
        Rect = rect;
    }
}