using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Databaskonstruktion {
	public class Program {
		public static readonly string DATABASE_CONNECTION_STRING
			= "Server=localhost;Database=REDACTED;User ID=root;Pooling=false;SslMode=None;Convert Zero datetime=true;";

		public static void Main (string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder (string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					_ = webBuilder.UseStartup<Startup>();
				});
	}
}
