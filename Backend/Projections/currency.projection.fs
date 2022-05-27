module currencyProjection

open events
open currencyEvents

type EventHandler<'e when 'e :> BaseEvent> = 
    abstract member handle: 'e -> unit

//type EventHandler<'E when 'E: null> = //with 'e: BaseEvent
//    abstract member handle int -> unit

type CurrencyEventHandler () =
    interface EventHandler<CurrencyEvent> with

        member this.handle ev =
            ()

//    rit     

