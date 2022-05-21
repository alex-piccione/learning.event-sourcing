namespace LES.WebAPI.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open LES.Shared.Entities
open currencyCommands


[<ApiController>]
[<Route("currency")>]
type CurrencyController (logger:ILogger<CurrencyController>) =
    inherit ControllerBase()
    
    let currencies:Currency list = [
        {Code= "EUR"; Name="Euro"}
        {Code= "GBP"; Name="Poud"}
    ]

    [<HttpGet>]
    member _.Get() =
        currencies

    [<HttpPost>]
    member _.Create( [<FromBody>]data:obj) =
        
        let command = Create({ Code = "" ;  Name = "" })
        currencyCommands.handleCommand(command)
        ()
