namespace LES.WebAPI.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open LES.Shared.Entities


[<ApiController>]
[<Route("currency")>]
type CurrencyController (logger:ILogger<CurrencyController>) =
    inherit ControllerBase()
    
    let currencies:Currency list = [
        {Code= "EUR"; Name="Euro"}
    ]

    [<HttpGet>]
    member _.Get() =
        currencies