namespace HogWarpChat;

public enum ChatTextStyle
{
	Default,
	Gryffindor,
	Hufflepuff,
	Ravenclaw,
	Slytherin,
	Admin,
	Dev,
	Server,
	Red,
	Blue,
	Green,
	Yellow,
	Magenta,
	Cyan
}

public sealed class ChatStyle(ChatTextStyle style, string value)
{
	public readonly ChatTextStyle Style = style;
	public readonly string Value = value;
}

public static class ChatStyles
{
	public static readonly ChatStyle Default = new (ChatTextStyle.Default, "Default");
	public static readonly ChatStyle Gryffindor = new (ChatTextStyle.Gryffindor, "Gryffindor");
	public static readonly ChatStyle Hufflepuff = new (ChatTextStyle.Hufflepuff, "Hufflepuff");
	public static readonly ChatStyle Ravenclaw = new (ChatTextStyle.Ravenclaw, "Ravenclaw");
	public static readonly ChatStyle Slytherin = new (ChatTextStyle.Slytherin, "Slytherin");
	public static readonly ChatStyle Admin = new (ChatTextStyle.Admin, "Admin");
	public static readonly ChatStyle Dev = new (ChatTextStyle.Dev, "Dev");
	public static readonly ChatStyle Server = new (ChatTextStyle.Server, "Server");
	public static readonly ChatStyle Red = new (ChatTextStyle.Red, "FF0000FF");
	public static readonly ChatStyle Blue = new (ChatTextStyle.Blue, "0000FFFF");
	public static readonly ChatStyle Green = new (ChatTextStyle.Green, "00FF00FF");
	public static readonly ChatStyle Yellow = new (ChatTextStyle.Yellow, "FFFF00FF");
	public static readonly ChatStyle Magenta = new (ChatTextStyle.Magenta, "FF00FFFF");
	public static readonly ChatStyle Cyan = new (ChatTextStyle.Cyan, "00FFFFFF");

	public static Dictionary<ChatTextStyle, ChatStyle> Styles = new()
	{
		{ ChatTextStyle.Default, Default },
		{ ChatTextStyle.Gryffindor, Gryffindor },
		{ ChatTextStyle.Hufflepuff, Hufflepuff },
		{ ChatTextStyle.Ravenclaw, Ravenclaw },
		{ ChatTextStyle.Slytherin, Slytherin },
		{ ChatTextStyle.Admin, Admin },
		{ ChatTextStyle.Dev, Dev },
		{ ChatTextStyle.Server, Server },
		{ ChatTextStyle.Red, Red },
		{ ChatTextStyle.Blue, Blue },
		{ ChatTextStyle.Green, Green },
		{ ChatTextStyle.Yellow, Yellow },
		{ ChatTextStyle.Magenta, Magenta },
		{ ChatTextStyle.Cyan, Cyan },
	};
}