var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Run(async (HttpContext context) =>
//{
//   await context.Response.WriteAsync("Welcome");
//});

//middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Welcome");
    await next(context);
});
//middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("\n");
    await next(context);
});

//We cannot call a chain of middlewares using the run command (first run must changed to 'Use')
//middleware 3
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("This is a simple way to Middlewares test");
});

app.Run();
