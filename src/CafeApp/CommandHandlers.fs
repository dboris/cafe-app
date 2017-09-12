module CafeApp.CommandHandlers

open System
open Domain
open States
open Events
open Commands

let execute state command =
    match command with
    | OpenTab tab -> [TabOpened tab]
    | _ -> failwith "TODO"

let evolve state command =
    let events = execute state command
    let newState = List.fold apply state events
    newState, events
