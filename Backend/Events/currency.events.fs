module currencyEvents

open events

type CreateCurrency = { Code:string; Name:string }
type DeleteCurrency = { Code:string }
type UpdateCurrency = { Code:string; Name:string }


type CreateCurrencyEvent (Code:string, Name:string) =
    inherit BaseEvent(nameOfEvent CreateCurrencyEvent)

type DeleteCurrencyEvent (Code:string) =
    inherit BaseEvent("DeleteCurrency")

type UpdateCurrencyEvent (Code:string, Name:string) =
    inherit BaseEvent("UpdateCurrency")