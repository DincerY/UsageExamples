using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

// var listener = new HttpListener();
// listener.Prefixes.Add("http://localhost:8080/");
// listener.Start();
//
// Console.WriteLine("API çalışıyor. http://localhost:8080/ adresine gidin.");
//
// while (true)
// {
//     var context = listener.GetContext();
//     ThreadPool.QueueUserWorkItem((o) =>
//     {
//         var ctx = o as HttpListenerContext;
//         if (ctx == null) return;
//
//         var response = ctx.Response;
//         var content = "<html><body><h1>Merhaba, dunya!</h1></body></html>";
//         var buffer = System.Text.Encoding.UTF8.GetBytes(content);
//
//         response.ContentLength64 = buffer.Length;
//         response.OutputStream.Write(buffer, 0, buffer.Length);
//         response.OutputStream.Close();
//     }, context);
// }

var host = new WebHostBuilder()
    .UseKestrel()
    .Configure(app =>
    {
        app.Use(async (context, next) =>
        {
            // Middleware önce çalışır
            await context.Response.WriteAsync("Middleware 1 - Önce\n");
            await next(); // Sonraki middleware'e geçiş

            // Middleware sonra çalışır
            await context.Response.WriteAsync("Middleware 1 - Sonra\n");
        });

        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Middleware 2 - Önce\n");
            await next();
            await context.Response.WriteAsync("Middleware 2 - Sonra\n");
        });

        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Middleware 3 - Önce\n");
            await next();
            await context.Response.WriteAsync("Middleware 3 - Sonra\n");
        });
        

        app.Run(async context =>
        {
            await context.Response.WriteAsync("API Yanıtı\n");
        });
    })
    .Build();

host.Run();



Console.WriteLine("Hello, World!");