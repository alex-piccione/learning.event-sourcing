module currencyCommands

open currencyEvents
open currencyAggregate

type CreateCurrencyCommand = {Code:string; Name:string}
type DeleteCurrencyCommand = {Code:string}
type UpdateCurrencyCommand = {Code:string; Name:string}

type CurrencyCommand = 
| Create of CreateCurrencyCommand
| Delete of DeleteCurrencyCommand
| Update of UpdateCurrencyCommand

let handleCommand_(command:CurrencyCommand) =

    let getItem code = currencyStorer.getItem code

    let (isChanged, item, event:CurrencyEvent) =
        match command with
        | Create c -> 
            match currencyStorer.exists c.Code with 
            | true -> failwith "Code already exists"
            | _ ->                
                let createEvent = CurrencyCreated(c.Code, c.Name)
                let item = CurrencyAggregate.createFromEvent createEvent             
                true, item, createEvent
        | Delete d -> false, getItem d.Code, CurrencyDeleted(d.Code)
        | Update u -> false, getItem u.Code, CurrencyUpdated(u.Code, u.Name)

    let updatedItem = if isChanged then item.applyEvent event else item

    currencyStorer.updateItem updatedItem

    EventStorer.storeEvent event


let handleCommand(command:CurrencyCommand) =
    let (item, event:CurrencyEvent) = 
        match command with
        | Create c ->
            match currencyStorer.exists c.Code with 
            | true -> failwith "Code already exists"
            | _ -> 
                let event = CurrencyCreated(c.Code, c.Name)
                let item = CurrencyAggregate.create event.Code event.Name event.Date  
                item, event
        | _ ->            
            let (code, event:CurrencyEvent) = 
                match command with                
                | Delete d -> d.Code, CurrencyDeleted(d.Code)
                | Update u -> u.Code, CurrencyUpdated(u.Code, u.Name)
                | Create _ -> failwith "impossible path for Create"
            let currentItem = currencyStorer.getItem code
            let item = currentItem.applyEvent event
            item, event    

    currencyStorer.updateItem item

    EventStorer.storeEvent event
    