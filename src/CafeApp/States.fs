module CafeApp.States

open System
open Domain
open Events

type States =
    | ClosedTab of Guid option
    | OpenedTab of Tab
    | PlacedOrder of Order
    | OrderInProgress of InProgressOrder
    | ServedOrder of Order

let apply state event =
    match state, event with
    | ClosedTab _, TabOpened tab -> OpenedTab tab
    | OpenedTab _, OrderPlaced order -> PlacedOrder order
    | _ -> state