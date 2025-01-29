namespace DI
{


    public static class UserIPTaskAsyncProgram
    {
        public static async Task Test()
        {
            using (var cts = new CancellationTokenSource())
            {
                Task userInputTask = Task.Run(() =>
                {
                    Console.WriteLine("Press any   to cancel...");
                    Console.ReadLine();

                    Console.ReadKey();
                    // cts.Cancel();
                });

                try
                {
                    await DoWorkAsync(cts.Token);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Task was canceled by the user.");
                }
            }
        }

        static async Task DoWorkAsync(CancellationToken token)
        {
            int count = 0;
            while (true)
            {
                token.ThrowIfCancellationRequested();
                Console.WriteLine($"Working... {++count}");
                await Task.Delay(5000);
            }
        }
    }

}