module events

open System

let nameOfEvent eventType = eventType.GetType().Name.Replace("Event", "")

type BaseEventData = { When:DateTime }

type BaseEvent (id:string, creationDate:DateTime, eventType:string) = 
    new (eventType:string) = BaseEvent(Guid.NewGuid().ToString(), DateTime.UtcNow, eventType)

    member this.Id = id
    member this.CreationDate = creationDate
    member this.EventType = eventType

type BaseEventData<'a> (When:DateTime, EventType:string, Event:'a) = 
    new (ev:'a) = BaseEventData<'a>(DateTime.UtcNow, ev.GetType().Name, ev)
    member this.EventType () = ""