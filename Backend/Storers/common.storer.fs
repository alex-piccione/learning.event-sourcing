module commonStorer

open MongoDB.Driver

let client = new MongoClient(MongoClientSettings.FromConnectionString(config.connectionString))
let databaseSettings = new MongoDatabaseSettings() // default settings
let database = client.GetDatabase(config.database, databaseSettings)


