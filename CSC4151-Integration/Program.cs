using PusherServer;
using System;
using System.Threading.Tasks;

namespace CSC4151_Integration
{
    class Program
    {
        private static readonly string _appId = "949498";
        private static readonly string _key = "71016f841831e7e31140";
        private static readonly string _secret = "157295391bd494d1b606";
        private static string message = "";
        private static Pusher _pusher;
        private static PusherClient.Pusher _client;

        public static async Task PusherPublish(string channelStr)
        {
            var options = new PusherOptions { Cluster = "us3", Encrypted = true };
            var clientOptions = new PusherClient.PusherOptions { Cluster = "us3", Encrypted = true };

            _pusher = new Pusher(_appId, _key, _secret, options);
            _client = new PusherClient.Pusher(_appId, clientOptions);
            

            var channel = _client.SubscribeAsync(channelStr).Result;

            channel.Bind("Notification", (dynamic data) =>
            {
                Console.WriteLine(data.message);
            });

            var result = await _pusher.TriggerAsync(channelStr, "Notification", new { message = "Test" });
        }

        static async Task Main(string[] args)
        {
            var channel = Guid.NewGuid().ToString();

            await PusherPublish(channel);


        }
    }
}
