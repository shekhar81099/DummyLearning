using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testapi.Services
{
    public class HostedSer : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class BackgroundSer : BackgroundService
    {
        private readonly QueueService _queueService;

        public BackgroundSer(QueueService queueService)
        {
            _queueService = queueService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_queueService.TryGetMessage(out string message))
                {
                    Console.WriteLine($"Processing Message: {message}");
                }

                await Task.Delay(1000, stoppingToken); // Wait 1 second before checking again
            }
        }
    }

    public class QueueService
    {

        private readonly ConcurrentQueue<string> _messages = new();

        public void AddMessage(string message)
        {
            _messages.Enqueue(message);
        }

        public bool TryGetMessage(out string message)
        {
            return _messages.TryDequeue(out message);
        }
    }
}