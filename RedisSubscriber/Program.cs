
using StackExchange.Redis;

ConnectionMultiplexer connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync("localhost:2000");

ISubscriber subscriber = connectionMultiplexer.GetSubscriber();

await subscriber.SubscribeAsync("firstChannel", (channel, value) =>
{
    Console.WriteLine(value);
});

Console.Read();