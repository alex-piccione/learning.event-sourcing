module events

open System

let nameOfEvent eventType = eventType.GetType().Name.Replace("Event", "")

type BaseEventData = { When:DateTime }

type BaseEvent (id:string, date:DateTime, eventType:string) as me = 
    new (eventType:string) = BaseEvent(Guid.NewGuid().ToString(), DateTime.UtcNow, eventType)

    member this.Id = id
    member this.Date = date
    member this.EventType = me.GetType().Name + " " + eventType
