// <copyright file="FilterConventionDescriptorMongoDbExtensions.cs" company="Silver Fern.">
// Copyright (c) Silver Fern. All rights reserved.
// </copyright>

using HotChocolate.Data.Filters;
using HotChocolate.Data.MongoDb.Filters;

namespace GraphQlServer;

public static class FilterConventionDescriptorMongoDbExtensions
{
    public static IFilterConventionDescriptor UseMongoDbCustomProvider(
        this IFilterConventionDescriptor descriptor
    ) =>
        descriptor.Provider(new MongoDbFilterProvider(x => x.AddDefaultMongoDbCustomFieldHandlers()));

    public static IFilterProviderDescriptor<MongoDbFilterVisitorContext>
        AddDefaultMongoDbCustomFieldHandlers(
            this IFilterProviderDescriptor<MongoDbFilterVisitorContext> descriptor
        )
    {
        descriptor.AddFieldHandler<MongoDbEqualsOperationHandler>();
        descriptor.AddFieldHandler<MongoDbNotEqualsOperationHandler>();

        descriptor.AddFieldHandler<MongoDbInOperationHandler>();
        descriptor.AddFieldHandler<MongoDbNotInOperationHandler>();

        descriptor.AddFieldHandler<MongoDbComparableGreaterThanHandler>();
        descriptor.AddFieldHandler<MongoDbComparableNotGreaterThanHandler>();
        descriptor.AddFieldHandler<MongoDbComparableGreaterThanOrEqualsHandler>();
        descriptor.AddFieldHandler<MongoDbComparableNotGreaterThanOrEqualsHandler>();
        descriptor.AddFieldHandler<MongoDbComparableLowerThanHandler>();
        descriptor.AddFieldHandler<MongoDbComparableNotLowerThanHandler>();
        descriptor.AddFieldHandler<MongoDbComparableLowerThanOrEqualsHandler>();
        descriptor.AddFieldHandler<MongoDbComparableNotLowerThanOrEqualsHandler>();

        descriptor.AddFieldHandler<MongoDbStringStartsWithHandler>();
        descriptor.AddFieldHandler<MongoDbStringNotStartsWithHandler>();
        descriptor.AddFieldHandler<MongoDbStringEndsWithHandler>();
        descriptor.AddFieldHandler<MongoDbStringNotEndsWithHandler>();
        descriptor.AddFieldHandler<MongoDbStringContainsHandler>();
        descriptor.AddFieldHandler<MongoDbStringNotContainsHandler>();

        descriptor.AddFieldHandler<MongoDbListAllOperationHandler>();
        descriptor.AddFieldHandler<MongoDbListAnyOperationHandler>();
        descriptor.AddFieldHandler<MongoDbListNoneOperationHandler>();
        descriptor.AddFieldHandler<MongoDbListSomeOperationHandler>();

        descriptor.AddFieldHandler<MongoDbDefaultFieldHandler>();

        return descriptor;
    }
}