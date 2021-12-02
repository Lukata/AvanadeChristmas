module Common

open System.IO

let getInputs =
    File.ReadAllLines "input.txt"
    |> Array.toList
    |> List.filter (fun line -> line <> "")