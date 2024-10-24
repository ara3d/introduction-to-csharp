namespace HttpServer
{
    public static class Program
    {
        public static WebServer Server;

        public static void Main(string[] args)
        {
            Server = new WebServer(Callback);
            Console.WriteLine($"Server running at {Server.Uri}. Press any key to stop");
            Console.ReadKey();
            Server.Stop();
        }

        public static void Callback(string verb,
            string path,
            IDictionary<string, string> parameters,
            StreamWriter output)
        {
            var title = $"{verb} request for {path}";
            Console.WriteLine(title);
            output.WriteLine(title);
            foreach (var kv in parameters)
            {
                output.WriteLine($"  {kv.Key} = {kv.Value}");
            }
        }
    }
}
