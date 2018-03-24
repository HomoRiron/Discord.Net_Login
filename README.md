# Discord.Net_Login


これはDiscordの一般アカウントをApiで操作できるようにしたものです

```csharp
DiscordLoginClient loginClient = new DiscordLoginClient();
DiscordSocketClient client = new DiscordSocketClient();
var token =  await loginClient.LoginWithEmailAndPasswordAsync("Email", "password");
await client.LoginAsync(TokenType.User, token);
await client.StartAsync();
```
