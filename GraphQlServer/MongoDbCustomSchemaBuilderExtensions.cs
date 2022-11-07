// <copyright file="MongoDbCustomSchemaBuilderExtensions.cs" company="Silver Fern.">
// Copyright (c) Silver Fern. All rights reserved.
// </copyright>

namespace GraphQlServer;

public static class MongoDbCustomSchemaBuilderExtensions
{
    public static ISchemaBuilder AddMongoDbCustomFiltering(this ISchemaBuilder builder)
        => builder.AddFiltering(x => x.AddMongoDbCustomDefaults());
}