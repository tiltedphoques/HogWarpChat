# HogWarp Chat

## Usage

### Builder

The following codeblock describes the usage of the `ChatMessage Builder` that allows for different styles inside the same message and some more details.

```cs
var builder = new ChatMessage.Builder();
builder.AddIcon(ChatIcon.Gryffindor);
builder.AddText("Default ", ChatTextStyle.Default);
builder.AddText("Gryffindor ", ChatTextStyle.Gryffindor);
builder.AddText("Hufflepuff ", ChatTextStyle.Hufflepuff);
builder.AddText("Ravenclaw ", ChatTextStyle.Ravenclaw);
builder.AddText("Slytherin ", ChatTextStyle.Slytherin);
builder.AddText("Admin ", ChatTextStyle.Admin);
builder.AddText("Dev ", ChatTextStyle.Dev);
builder.AddText("Server ", ChatTextStyle.Server);
builder.AddText("Red ", ChatTextStyle.Red);
builder.AddText("Blue ", ChatTextStyle.Blue);
builder.AddText("Green ", ChatTextStyle.Green);
builder.AddText("Yellow ", ChatTextStyle.Yellow);
builder.AddText("Magenta ", ChatTextStyle.Magenta);
builder.AddText("Cyan ", ChatTextStyle.Cyan);
builder.AddSender(player.Username, ChatTextStyle.Server);
SendMessage(player, builder.Build().Message);
```

