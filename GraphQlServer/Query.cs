// <copyright file="Query.cs" company="Silver Fern.">
// Copyright (c) Silver Fern. All rights reserved.
// </copyright>

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace GraphQlServer;

public sealed class Query
{
    [UseFiltering]
    public async Task<IExecutable<Person>> GetPerson([Service] IMongoDatabase database)
    {
        IMongoCollection<Person> collection = database.GetCollection<Person>(nameof(Person));
        FilterDefinition<Person> filter = Builders<Person>.Filter.Empty;
        Person person = await collection.Find(filter).FirstOrDefaultAsync();
        if (person is null)
        {
            await collection.InsertManyAsync(new[]
            {
                new Person { Name = "Chris" },
                new Person { Name = "CHRIS" },
                new Person { Name = "chris" },
                new Person { Name = "chris Matt" },
            });
        }
        return collection.AsExecutable();
    }
}

public sealed class Person
{
    [BsonId]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
}