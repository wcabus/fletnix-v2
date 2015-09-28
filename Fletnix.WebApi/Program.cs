using System;
using Microsoft.Owin.Hosting;

namespace Fletnix.WebApi
{
    public sealed class Program
    {
        public const string BaseUri = "http://localhost:8123";
        public static void Main()
        {
            using (WebApp.Start<Startup>(BaseUri))
            {
                Console.WriteLine($"OWIN host started, listening at {BaseUri}");
                Console.ReadLine();
            }
        }
    }
}