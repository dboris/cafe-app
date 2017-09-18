module CafeApp.CommandHandlers

open System
open Chessie.ErrorHandling

open Domain
open States
open Events
open Commands
open Errors

let handleOpenTab tab = function
    | ClosedTab _ -> [TabOpened tab] |> ok
    | _ -> fail TabAlreadyOpened

let handlePlaceOrder order = function
    | OpenedTab _ -> 
        if List.isEmpty order.Food && List.isEmpty order.Drinks
        then fail CannotPlaceEmptyOrder
        else [OrderPlaced order] |> ok
    | ClosedTab _ -> fail CannotOrderWithClosedTab
    | PlacedOrder _ -> fail OrderAlreadyPlaced
    | _ -> failwith "TODO"

let execute state = function
    | OpenTab tab -> handleOpenTab tab state
    | PlaceOrder order -> handlePlaceOrder order state
    | _ -> failwith "TODO"

let evolve state command =
    match execute state command with
    | Ok (events, _) ->
        let newState = List.fold apply state events
        (newState, events) |> ok
    | Bad err -> Bad err
