var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.Map("/Products", appBuilder =>
    {
        appBuilder.Use(async (Context, next) =>
        {
            var name = Context.Request.Query["name"];
            if (!string.IsNullOrWhiteSpace(name))
            {
                Context.Items.Add("name", "Reza");
            }
            await next.Invoke();
        });
        appBuilder.Run(async Context =>
        {
            {
                var name = Context.Items["name"];
                await Context.Response.WriteAsync($"my name is {name}");
            }
        });
    });
    app.Run();




    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    context.Items.Add("Name", "Reza");
    await next.Invoke();
});

app.Run(async context =>
{
    var cnt = context.Items["Name"];
    await context.Response.WriteAsync("Run executed successfully");
});

app.Run(async context =>
{
    var cnt = context.Items["Name"];
    await context.Response.WriteAsync("Run executed successfully");
});



//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();



//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

