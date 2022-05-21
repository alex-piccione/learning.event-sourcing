module currencyEvents

open events

//type CurrencyCreated = { Code:string; Name:string }
//type CurrencyDeleted = { Code:string }
//type CurrencyUpdated = { Code:string; Name:string }

type CurrencyCreated (Code:string, Name:string) as me =
    inherit BaseEvent(nameof me)

type CurrencyDeleted (Code:string) =
    inherit BaseEvent(nameOfEvent CurrencyDeleted)

type CurrencyUpdated (Code:string, Name:string) =
    inherit BaseEvent("CurrencyUpdated")