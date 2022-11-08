// <copyright file="MongoDbInvariantStringContainsHandler.cs" company="Silver Fern.">
// Copyright (c) Silver Fern. All rights reserved.
// </copyright>

using System.Text.RegularExpressions;
using HotChocolate.Data.Filters;
using HotChocolate.Data.MongoDb;
using HotChocolate.Data.MongoDb.Filters;
using HotChocolate.Language;
using MongoDB.Bson;

namespace GraphQlServer;

public sealed class MongoDbInsensitiveStringContainsHandler : MongoDbStringOperationHandler
{
    /// <inheritdoc />
    public MongoDbInsensitiveStringContainsHandler(InputParser inputParser) : base(inputParser)
    {
        CanBeNull = false;
    }

    /// <inheritdoc />
    public override MongoDbFilterDefinition HandleOperation(
        MongoDbFilterVisitorContext context, 
        IFilterOperationField field, 
        IValueNode value, 
        object? parsedValue
    )
    {
        if (parsedValue is string str)
        {
            const string options = "i"; //Case Insensitive
            BsonRegularExpression bsonRegex = new($"{Regex.Escape(str)}", options);
            var doc = new MongoDbFilterOperation(
                "$regex",
                bsonRegex);

            return new MongoDbFilterOperation(context.GetMongoFilterScope().GetPath(), doc);
        }

        throw new InvalidOperationException();
    }

    /// <inheritdoc />
    protected override int Operation => DefaultFilterOperations.Contains;
}