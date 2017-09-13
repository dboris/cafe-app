module CafeApp.TestsDSL

open NUnit.Framework
open Swensen.Unquote
open Chessie.ErrorHandling

open States
open CommandHandlers
open Events
open Errors

let Given (state : States) = state

let When command state = command, state

let ThenStateShouldBe expectedState (command, state) =
    match evolve state command with
    | Ok ((actualState, events), _) ->
        actualState =! expectedState
        events |> Some
    | Bad err ->
        sprintf "Expected: %A, but actual: %A" expectedState err.Head |> Assert.Fail
        None

let WithEvents (expectedEvents : Event list) actualEvents =
    match actualEvents with
    | Some actualEvents' ->
        actualEvents' =! expectedEvents
    | None ->
        [] =! expectedEvents

let ShouldFailWith (expectedError : Error) (command, state) =
    match evolve state command with
    | Bad err ->
        err.Head =! expectedError
    | Ok (r, _) ->
        sprintf "Expected: %A, but actual: %A" expectedError r |> Assert.Fail
