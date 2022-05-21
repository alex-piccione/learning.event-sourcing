module currencyAggregate

open System
open LES.Shared.Entities

//type CurrencyDto = { Code: string; Name:string;}

//let apply () = { CurrencyDto }

//let applyCreated (command:CurrencyCreated) = 

//    {Currency with Code= }

type AggregateRoot = { Version: int64 }

type CurrencyAggregate = { 
    Code:string 
    Name:string
    Version: int64
    CreationDate: DateTime
    IsDeleted:bool
}
    //inherit AggregateRoot

type CurrencyAggregate with
    static member create code name date = { Version=0; Code=code; Name=name; CreationDate=date; IsDeleted=false}
    //member this.Create code name = { this with Version = 0 }
    member this.delete () = { this with IsDeleted = true}
    member this.changeName newName = { this with Name=newName; }

//type Currency with 
//    apply()