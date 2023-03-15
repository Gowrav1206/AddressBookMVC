using AddressBook.Data;
using AddressBook.Interfaces;
using AddressBook.Profiles;
using AddressBook.Repositories;
using AddressBook.Services;
using SimpleInjector;
using SimpleInjector.Lifestyles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper((cfg =>
{
    cfg.AddProfile<ContactProfile>();
}));

var container = new Container();
container.Options.DefaultLifestyle = Lifestyle.Transient;                          
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

builder.Services.AddSimpleInjector(container,options =>
{
    options.AddAspNetCore().AddControllerActivation();
    options.AddAspNetCore().AddViewComponentActivation();
});


//EF
/*builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
 builder.Configuration.GetConnectionString("DefaultConnection")
 ));
container.Register<IContactServices, EFContactRepository>();
container.Register<ContactServices>();*/

//Dapper
container.Register<IContactRepository, DapperContactRepository>();
container.Register<ContactsDbContext>();
container.Register<IContactServices, ContactServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=contact}/{action=Index}/{id?}");

app.Run();