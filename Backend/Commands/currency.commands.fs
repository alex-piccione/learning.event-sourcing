module currencyCommands

open events
open currencyEvents

type CreateCurrencyCommand = {Code:string; Name:string}
type DeleteCurrencyCommand = {Code:string}
type UpdateCurrencyCommand = {Code:string; Name:string}

//let handleCreateCommand command =
//    EventStorer.storeEvent (CreateCurrencyEvent(command.Code, command.Name))

type CurrencyCommand = 
| Create of CreateCurrencyCommand
| Delete of DeleteCurrencyCommand
| Update of UpdateCurrencyCommand

let handleCommand(command:CurrencyCommand) =
    let event:BaseEvent = 
        match command with
        | Create c -> 
            match currencyStorer.exists c.Code with 
            | true -> failwith "Code already exists"
            | _ -> CurrencyCreated(c.Code, c.Name)
        | Delete d -> CurrencyDeleted(d.Code)
        | Update c -> CurrencyUpdated(c.Code, c.Name)

    let id = event.Id
    EventStorer.storeEvent event
