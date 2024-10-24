using System.IO.Pipes;

namespace NamedPipeDemo
{
    public static class Program
    {

        public static void Main(string[] args)
        {
            var pipeName = "DemoPipe";

            // Attempt to connect to an existing server
            var isServer = false;
            NamedPipeClientStream pipeClient = null;

            try
            {
                pipeClient = new NamedPipeClientStream(".", pipeName, PipeDirection.InOut);
                pipeClient.Connect(500); // 0.5-second timeout
            }
            catch (TimeoutException)
            {
                // No server is running; this instance will become the server
                isServer = true;
            }

            if (isServer)
            {
                Console.WriteLine("Starting server...");
                Server.Run(pipeName);
            }
            else
            {
                Console.WriteLine("Starting client ...");
                Client.Run(pipeClient);
            }

        }

    }
}