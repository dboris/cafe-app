module CafeApp.Domain

open System

type Tab = {Id : Guid; TableNumber : int}
type Item = {MenuNumber : int; Price : decimal; Name : string}
type Food = Food of Item
type Drink = Drink of Item
type Payment = {Tab : Tab; Amount : decimal}
type Order = {Tab : Tab; Food : Food list; Drinks : Drink list}
type InProgressOrder = {
    PlacedOrder : Order
    ServedDrinks : Drink list
    ServedFood : Food list
    PreparedFood : Food list }