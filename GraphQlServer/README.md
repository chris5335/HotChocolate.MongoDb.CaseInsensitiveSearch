# Handling case insensitive searching in HotChocolate and MongoDb

## Nuget
| Package                                                                  | dotnet cli                                     |
|--------------------------------------------------------------------------|------------------------------------------------|
| [HotChocolate.AspNetCore](https://github.com/chillicream/hotchocolate)   | `dotnet add package HotChocolate.AspNetCore`   |
| [HotChocolate.Data](https://github.com/chillicream/hotchocolate)         | `dotnet add package HotChocolate.Data`         |
| [HotChocolate.Data.MongoDb](https://github.com/chillicream/hotchocolate) | `dotnet add package HotChocolate.Data.MongoDb` |
| [MongoDb](https://github.com/mongodb/mongo-csharp-driver)                | `dotnet add package MongoDB.Driver`            |

## Description
This simply overrides the `contains` field handler that is provided by the default HC MongoDb package. You would also need to update the other field handlers accordingly to also be case insensitive.
The main class used to make this change is the `MongoDbInsensitiveStringContainsHandler` and it is then wired up in the Program.cs page.
The other classes are where I was going to override other field handlers and then make its own `IRequestExecutorBuilder`.
I don't think this code requires HC preview 13, but that's what I'm using here.

Please consider giving this a star if it was helpful to you.

Thanks,
Chris
