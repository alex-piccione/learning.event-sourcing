module EventStorer

open MongoDB.Driver
open MongoDB.Bson.Serialization
open events

let client = new MongoClient(MongoClientSettings.FromConnectionString(config.connectionString))
let databaseSettings = new MongoDatabaseSettings() // default settings
let database = client.GetDatabase(config.database, databaseSettings)
let collection = database.GetCollection<BaseEvent>("Events");

if not(BsonClassMap.IsClassMapRegistered(typeof<BaseEvent>)) then
    let map = BsonClassMap<BaseEvent>()
    map.AutoMap()
    map.MapIdMember( (fun x -> x.Id)) |> ignore
    //map.SetIgnoreExtraElements true
    BsonClassMap.RegisterClassMap(map)

let storeEvent (event:BaseEvent) =
    collection.InsertOne(event)
