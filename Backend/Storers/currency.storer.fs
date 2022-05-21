module currencyStorer

open System.Linq
//open LES.Shared.Entities
open commonStorer
open MongoDB.Bson.Serialization
open MongoDB.Driver
open currencyAggregate

let collection = database.GetCollection<CurrencyAggregate>("Currency");

if not(BsonClassMap.IsClassMapRegistered(typeof<CurrencyAggregate>)) then
    let map = BsonClassMap<CurrencyAggregate>()
    map.AutoMap()
    map.MapIdMember( (fun x -> x.Code)) |> ignore
    //map.SetIgnoreExtraElements true
    BsonClassMap.RegisterClassMap(map)

let exists code =
    collection.FindAsync((fun x -> x.Code = code)).Result.Any()

let getItem code =
    let item = collection.FindAsync((fun x -> x.Code = code)).Result.SingleOrDefault()
    item

let updateItem item =
    collection.FindOneAndReplace<CurrencyAggregate>((fun x -> x.Code = item.Code), item) |> ignore