// <copyright file="MongoDbDataRequestBuilderExtensions.cs" company="Silver Fern.">
// Copyright (c) Silver Fern. All rights reserved.
// </copyright>

using GraphQlServer;
using HotChocolate.Execution.Configuration;
// ReSharper disable CheckNamespace

namespace Microsoft.Extensions.DependencyInjection;

public static class MongoDbDataRequestBuilderExtensions
{
    public static IRequestExecutorBuilder AddMongoDbCustomFiltering(
        this IRequestExecutorBuilder builder) =>
        builder.ConfigureSchema(s => s.AddMongoDbCustomFiltering());
}