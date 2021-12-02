module Day_1
open System.IO

type DifferenceDirection =
    | None
    | Decreasing
    | Increasing

let getDifferenceDirection measurements =
    match measurements with
    | [ first ; second ] when first > second -> DifferenceDirection.Decreasing
    | [ first ; second ] when first < second -> DifferenceDirection.Increasing
    | [ _ ] -> DifferenceDirection.None

let getMeasurements =
    File.ReadAllLines "Day_1.input.txt"
    |> Array.toList
    |> List.filter (fun line -> line <> "")
    |> List.map int

let getMeasurementsDifferenceDirections measurements =
    measurements
    |> List.windowed 2
    |> List.map getDifferenceDirection

let getNumberOfIncreases measurementDifferenceDirections =
    measurementDifferenceDirections
    |> List.filter (fun direction -> direction = DifferenceDirection.Increasing)
    |> List.length

let getPuzzleAnswer =
    getMeasurements
    |> getMeasurementsDifferenceDirections
    |> getNumberOfIncreases