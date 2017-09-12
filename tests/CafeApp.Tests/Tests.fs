module CafeApp.Tests

open System
open NUnit.Framework
open Swensen.Unquote

open TestsDSL

module OpenTabTests =
  open Domain
  open Events
  open Commands
  open States

  [<Test>]
  let ``can open a new tab`` () =
    let tab = {Id = Guid.NewGuid (); TableNumber = 1}
    Given (ClosedTab None)
    |> When (OpenTab tab)
    |> ThenStateShouldBe (OpenedTab tab)
    |> WithEvents [TabOpened tab]
