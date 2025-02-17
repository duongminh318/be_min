// See https://aka.ms/new-console-template for more information
using CreateDatabaseByEFCore;
using CreatedDBByEFCore;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

 var context = new EcommerceDbContext();
context.Database.Migrate();
Console.WriteLine( "Initialize DB success");
DbInitializer.Initialize();