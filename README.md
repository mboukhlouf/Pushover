## About
> Pushover is the ideal application for sending (free) push notifications to iOS and Android devices, using this very simple API.

## Pushover-CSharp library
> Pushover-CSharp library is a library in C# for using the Pushover (https://pushover.net) API. https://pushover.net/api

## Example 1

```csharp

	static void Main(string[] args)
	{
		PushoverApi api = new PushoverApi("token");

		bool result = api.Send("token", "hello world");
		Console.Read();
	}
		
```

## Example 2

```csharp

	static void Main(string[] args)
	{
		PushoverApi api = new PushoverApi("token");

		PushoverMessage message = new PushoverMessage()
		{
			Title = "title",
			Message = "message",
			Priority = Priority.High,
			Sound = "magic",
			Url = "https://www.github.com",
			UrlTitle = "Github",
		};

		bool result = api.Send("token", message);
		Console.Read();
	}
		
```