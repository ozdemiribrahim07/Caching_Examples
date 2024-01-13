
using StackExchange.Redis;

ConnectionMultiplexer connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync("localhost:2000"); //Redis sunucusu için bağlantı cümlesi oluşturuyoruz.

ISubscriber subscriber = connectionMultiplexer.GetSubscriber();
// Subscriber bağlantısı oluşturduk.

while (true)
{
    Console.Write("Message : ");
    string message = Console.ReadLine();

    await subscriber.PublishAsync("firstChannel", message);
}



