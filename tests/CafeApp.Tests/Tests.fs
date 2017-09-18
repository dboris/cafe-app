module CafeApp.Tests

open System
open NUnit.Framework
open Swensen.Unquote

open TestsDSL
open Domain
open Events
open Commands
open States
open Errors

module OpenTabTests =
  [<Test>]
  let ``can open a new tab`` () =
    let tab = {Id = Guid.NewGuid (); TableNumber = 1}
    Given (ClosedTab None)
    |> When (OpenTab tab)
    |> ThenStateShouldBe (OpenedTab tab)
    |> WithEvents [TabOpened tab]

  [<Test>]
  let ``cannot open an already opened tab`` () =
    let tab = {Id = Guid.NewGuid (); TableNumber = 1}
    Given (OpenedTab tab)
    |> When (OpenTab tab)
    |> ShouldFailWith TabAlreadyOpened

module PlaceOrderTests =
    let tab = {Id = Guid.NewGuid (); TableNumber = 1}
    let coke = Drink {MenuNumber = 1; Name="Coke"; Price=1.5m}
    let order = {Tab = tab; Food = []; Drinks = []}

    [<Test>]
    let ``can place only drinks order`` () =
        let order = {order with Drinks = [coke]}
        Given (OpenedTab tab)
        |> When (PlaceOrder order)
        |> ThenStateShouldBe (PlacedOrder order)
        |> WithEvents [OrderPlaced order]

    [<Test>]
    let ``cannot place empty order`` () =
        Given (OpenedTab tab)
        |> When (PlaceOrder order)
        |> ShouldFailWith CannotPlaceEmptyOrder
