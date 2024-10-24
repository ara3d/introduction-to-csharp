using System.IO.Pipes;

namespace NamedPipeDemo
{
    public static class Server
    {
        public const int MaxClients = 5;

        public static void Run(string pipeName)
        {
            while (true)
            {
                var pipeServer = new NamedPipeServerStream(pipeName, PipeDirection.InOut, MaxClients);
                Console.WriteLine("Waiting for client connection...");
                pipeServer.WaitForConnection();

                Console.WriteLine("Client connected.");

                // Handle each client connection in a new task
                Task.Run(() => HandleClient(pipeServer));
            }
        }

        private static void HandleClient(NamedPipeServerStream pipeServer)
        {
            using (pipeServer)
            {
                using (var sr = new StreamReader(pipeServer))
                using (var sw = new StreamWriter(pipeServer))
                {
                    sw.AutoFlush = true;
                    var clientName = sr.ReadLine();
                    Console.WriteLine($"Client name: {clientName}");

                    string message;
                    while ((message = sr.ReadLine()) != null)
                    {
                        // Write the message to the console 
                        Console.WriteLine($"[{clientName}]: {message}");

                        // Echo the message back to the client
                        sw.WriteLine($"Server received: {message}");
                    }
                }
            }
        }
    }
}