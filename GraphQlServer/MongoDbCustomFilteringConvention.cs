// <copyright file="MongoDbCustomFilteringConvention.cs" company="Silver Fern.">
// Copyright (c) Silver Fern. All rights reserved.
// </copyright>

using HotChocolate.Data.Filters;
using HotChocolate.Data.MongoDb.Filters;

namespace GraphQlServer;

public class MongoDbCustomFilteringConvention: FilterConvention
{
    /// <inheritdoc />
    protected override void Configure(IFilterConventionDescriptor descriptor)
    {
        descriptor.AddDefaults();
        descriptor.Provider(new MongoDbFilterProvider(x=> x.AddDefaultMongoDbFieldHandlers().AddFieldHandler<MongoDbInsensitiveStringContainsHandler>()));
    }
}