module CafeApp.Commands

open System
open Domain

type Command =
    | OpenTab of Tab
    | PlaceOrder of Order
    | ServeDrink of Drink * Guid
    | PrepareFood of Food * Guid
    | ServeFood of Food * Guid
    | ServeOrder of Order * Payment
    | CloseTab of Payment
