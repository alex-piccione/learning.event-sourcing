module currencyCommands

open events
open currencyEvents
open currencyAggregate

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

    let getItem code = currencyStorer.getItem code

    let (item, baseEvent:CurrencyEvent) = //:(string, BaseEvent) = 
        match command with
        | Create c -> 
            match currencyStorer.exists c.Code with 
            | true -> failwith "Code already exists"
            | _ ->                
                let event = CurrencyCreated(c.Code, c.Name)
                let item = CurrencyAggregate.create event.Code event.Name event.EventDate                
                item, event
        | Delete d -> getItem d.Code, CurrencyDeleted(d.Code)
        | Update u -> getItem u.Code, CurrencyUpdated(u.Code, u.Name)

    let updatedItem = item.applyEvent baseEvent

    currencyStorer.updateItem updatedItem

    EventStorer.storeEvent baseEvent
