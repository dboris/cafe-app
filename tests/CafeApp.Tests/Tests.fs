module CafeApp.Tests

open CafeApp
open NUnit.Framework
open Swensen.Unquote

[<Test>]
let ``hello returns 42`` () =
  let result = Library.hello 42
  printfn "%i" result
  // Assert.AreEqual(42,result)
  42 =! result