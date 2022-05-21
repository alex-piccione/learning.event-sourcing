module currencyStorer

open System.Linq
open LES.Shared.Entities
open commonStorer
open MongoDB.Bson.Serialization
open MongoDB.Driver

let collection = database.GetCollection<Currency>("Currency");

if not(BsonClassMap.IsClassMapRegistered(typeof<Currency>)) then
    let map = BsonClassMap<Currency>()
    map.AutoMap()
    map.MapIdMember( (fun x -> x.Code)) |> ignore
    //map.SetIgnoreExtraElements true
    BsonClassMap.RegisterClassMap(map)

let exists code =
    collection.FindAsync<Currency>((fun x -> x.Code = code)).Result.Any()

