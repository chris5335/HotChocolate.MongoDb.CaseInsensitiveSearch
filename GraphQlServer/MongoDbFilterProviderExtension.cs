// <copyright file="MongoDbFilterProviderExtension.cs" company="Silver Fern.">
// Copyright (c) Silver Fern. All rights reserved.
// </copyright>

using HotChocolate.Data.Filters;
using HotChocolate.Data.MongoDb.Filters;

namespace GraphQlServer;

public class MongoDbFilterProviderExtension: FilterProviderExtensions<MongoDbFilterVisitorContext>
{
    public MongoDbFilterProviderExtension()
    {
        
    }

    public MongoDbFilterProviderExtension(Action<IFilterProviderDescriptor<MongoDbFilterVisitorContext>> configure): base(configure)
    {
        
    }
}