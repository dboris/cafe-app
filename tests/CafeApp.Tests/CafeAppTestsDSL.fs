module CafeApp.TestsDSL

open NUnit.Framework
open Swensen.Unquote

open States
open CommandHandlers

let Given (state : States) = state

let When command state = command, state

let ThenStateShouldBe expectedState (command, state) =
    let actualState, events = evolve state command
    actualState =! expectedState
    events

let WithEvents expectedEvents actualEvents =
    actualEvents =! expectedEvents