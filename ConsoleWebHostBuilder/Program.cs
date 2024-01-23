using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;



var host = new WebHostBuilder()
    .UseKestrel()
    .Configure(app =>
    {
        app.Run(async context =>
        {
            await context.Response.WriteAsync("<a href=\"https://www.youtube.com/\" target=\"_blank\"><button type=\"button\">Go to YouTube</button></a>");
        });
    })
    .Build();

host.Run();


