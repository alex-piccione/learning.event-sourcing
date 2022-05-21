module events

open System

let nameOfEvent eventType = eventType.GetType().Name.Replace("Event", "")

type BaseEventData = { When:DateTime }

type BaseEvent (id:string, eventDate:DateTime, eventType:string) as me = 
    new (eventType:string) = BaseEvent(Guid.NewGuid().ToString(), DateTime.UtcNow, eventType)

    member this.Id = id
    member this.EventDate = eventDate
    member this.EventType = me.GetType().Name + " " + eventType

type BaseEventData<'a> (When:DateTime, EventType:string, Event:'a) = 
    new (ev:'a) = BaseEventData<'a>(DateTime.UtcNow, ev.GetType().Name, ev)
    member this.EventType () = ""