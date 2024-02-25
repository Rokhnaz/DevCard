using DotNetCoreFundamental2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    //var configurationurl = Configuration.GetValue<string>("ApplicationUrl");
}
//my custom middle ware
app.UseCustomLoggerExtension();

app.Map("/Rokhnaz", appbuider =>
{
    appbuider.Map("/Reza", AppBld =>
    {
        AppBld.Run(async Context =>
        {
            await Context.Response.WriteAsync("LOOOOOve");
        });
    });

    appbuider.Use(async (Context, next) =>
    {
        Context.Items.Add("id", 100);
        next.Invoke();
    });
    appbuider.Run(async Context =>
    {
        var q = Context.Items["id"];
        Context.Response.WriteAsync("Good job Rokhnaz your grade is: " + q.ToString());
    });
});
app.UseWhen(context => context.Request.Query.ContainsKey("Title"), builder =>
{
    builder.Run(async Context =>
    {
        await Context.Response.WriteAsync("This is mapwhen for Title");
    });
});

app.MapWhen(context => context.Request.Query.ContainsKey("Branch"), builder =>
{
    builder.Run(async Context =>
    {
        await Context.Response.WriteAsync("This is mapwhen for Branch");
    });
});

app.Map("/Products", applicationBuilder =>
{
    applicationBuilder.Map("/Details", HandelProductDetails());

    applicationBuilder.Use(async (Context, next) =>
    {
        var name = Context.Request.Query["MyName"];
        if (!string.IsNullOrWhiteSpace(name))
            Context.Items.Add("MyName", name);
        await next.Invoke();
    });
    applicationBuilder.Run(async Context =>
    {
        var x = Context.Items["MyName"];
        await Context.Response.WriteAsync("End of map pipeline" + x.ToString());
    });

});

Action<IApplicationBuilder> HandelProductDetails()
{
    return builder =>
    {
        builder.Run(async Context =>
        {
            await Context.Response.WriteAsync("this is detail page");
        });
    };
}

app.Use(async (Context, next) =>
{  
    Context.Items.Add("Name", "Rokhnaz");
    await next.Invoke();
});

app.Use(async (Context, next) =>
{
    var q = Context.Request.Query["id"];
    await next.Invoke();
    // await Context.Response.WriteAsync("result is: " );

});



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//app.Run(async Context =>
//{
//    var ct = Context.Items["Name"];
//    var q = Context.Request.Query["id"];
//    await Context.Response.WriteAsync("result is: " + ct.ToString() + q);
//});
app.Run();


