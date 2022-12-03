// <copyright file="Program.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API
{
    /// <summary>
    /// This is the main driver class for the entire API.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// This is the main driver method.
        /// </summary>
        /// <param name="args">Any project specific CLI arguments.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// This method creates an instance of type <see cref="IHostBuilder"/>.
        /// </summary>
        /// <param name="args">Project specific CLI arguments.</param>
        /// <returns>A type of <see cref="IHostBuilder"/>.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}