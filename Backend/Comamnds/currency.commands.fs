module currencyCommands

open events
open currencyEvents

type CreateCurrencyCommand = {Code:string; Name:string}
type DeleteCurrencyCommand = {Code:string}
type UpdateCurrencyCommand = {Code:string; Name:string}

let handleCreateCommand command =
    EventRepository.storeEvent (CreateCurrencyEvent(command.Code, command.Name))

type CurrencyCommand = 
| Create of CreateCurrencyCommand
| Delete of DeleteCurrencyCommand
| Update of UpdateCurrencyCommand

let handleCommand(command:CurrencyCommand) =
    let event:BaseEvent = 
        match command with
        | Create c -> CreateCurrencyEvent(c.Code, c.Name)
        | Delete d -> DeleteCurrencyEvent(d.Code)
        | Update c -> UpdateCurrencyEvent(c.Code, c.Name)

    EventRepository.storeEvent event
