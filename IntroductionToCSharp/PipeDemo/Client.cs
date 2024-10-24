using System.IO.Pipes;

namespace NamedPipeDemo
{
    public static class Client
    {
        public static void Run(NamedPipeClientStream pipeClient)
        {
            using (var sr = new StreamReader(pipeClient))
            using (var sw = new StreamWriter(pipeClient) { AutoFlush = true })
            {
                // Send client name
                Console.Write("Enter your name: ");
                var clientName = Console.ReadLine();
                sw.WriteLine(clientName);

                // Send messages to server
                Console.WriteLine("Type messages to send to server (type 'exit' to quit):");
                string input;
                while ((input = Console.ReadLine()) != "exit")
                {
                    sw.WriteLine(input);
                    // Read server response
                    var response = sr.ReadLine();
                    Console.WriteLine($"Server: {response}");
                }
            }
        }
    }
}