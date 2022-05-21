module currencyEvents

open events
open currencyAggregate
//open LES.Shared.Entities

//type CurrencyCreated = { Code:string; Name:string }
//type CurrencyDeleted = { Code:string }
//type CurrencyUpdated = { Code:string; Name:string }

type CurrencyEvent (eventName:string) = 
    inherit BaseEvent(eventName)

type CurrencyCreated (code:string, name:string) as me =
    inherit CurrencyEvent(nameof me)
    member this.Code = code
    member this.Name = name

type CurrencyDeleted (code:string) =
    inherit CurrencyEvent(nameOfEvent CurrencyDeleted)
    member this.Code = code

type CurrencyUpdated (code:string, name:string) =
    inherit CurrencyEvent("CurrencyUpdated")
    member this.Code = code
    member this.NewName = name


type CurrencyEvent__ =    
| Created of CurrencyCreated
| Deleted of CurrencyDeleted
| Updated of CurrencyUpdated

type CurrencyAggregate with
    member this.applyEvent event: CurrencyAggregate =
        match (event:CurrencyEvent) with
        | :? CurrencyCreated -> this 
        | :? CurrencyDeleted -> { this with IsDeleted = true }
        | :? CurrencyUpdated as ev -> { this with Name = ev.NewName }
        | _ -> failwith "wrong event for aggregate"