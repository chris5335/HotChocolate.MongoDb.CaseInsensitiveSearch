using GraphQlServer;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
MongoClient client = new("mongodb://mongoadmin:secret@localhost:27017/");
builder.Services
    .AddSingleton(client.GetDatabase("TestSearchDb"))
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMongoDbFiltering()
    .AddConvention<IFilterConvention>(new FilterConventionExtension(x =>
        x.AddProviderExtension(
            new MongoDbFilterProviderExtension(y => 
                y.AddFieldHandler<MongoDbInsensitiveStringContainsHandler>()))))
    // .AddMongoDbCustomFiltering()
    ;

var app = builder.Build();

app.MapGraphQL();
app.Run();