// <copyright file="MongoDbFilterConventionDescriptorExtensions.cs" company="Silver Fern.">
// Copyright (c) Silver Fern. All rights reserved.
// </copyright>

using HotChocolate.Data.Filters;
using HotChocolate.Data.MongoDb.Filters;

namespace GraphQlServer;

public static class MongoDbFilterConventionDescriptorExtensions
{
    public static IFilterConventionDescriptor AddMongoDbCustomDefaults(
        this IFilterConventionDescriptor descriptor) =>
        descriptor
            .AddDefaultMongoDbOperations()
            .BindDefaultMongoDbTypes()
            .UseMongoDbCustomProvider();
}