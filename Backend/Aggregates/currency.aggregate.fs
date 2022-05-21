module currencyAggregate

open System

type AggregateRoot = { Version: int64 }

type CurrencyAggregate = { 
    Code:string 
    Name:string
    Version: int64
    CreationDate: DateTime
    IsDeleted:bool
}

type CurrencyAggregate with
    static member create code name date = { Version=0; Code=code; Name=name; CreationDate=date; IsDeleted=false}
    member this.delete () = { this with IsDeleted = true}
    member this.changeName newName = { this with Name=newName; }
