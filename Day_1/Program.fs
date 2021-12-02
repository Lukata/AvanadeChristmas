type DifferenceDirection =
    | Inapplicable
    | Decreasing
    | Increasing

let getDifferenceDirection measurements =
    match measurements with
    | [ first ; second ] when first > second -> DifferenceDirection.Decreasing
    | [ first ; second ] when first < second -> DifferenceDirection.Increasing
    | _ -> DifferenceDirection.Inapplicable

let getDifferenceDirections measurements =
    measurements
    |> List.windowed 2
    |> List.map getDifferenceDirection

let countIncreases measurements =
    measurements
    |> getDifferenceDirections
    |> List.filter (fun direction -> direction = DifferenceDirection.Increasing)
    |> List.length

let getMeasures =
    Common.getInputs
    |> List.map int

let getPuzzle1Answer =
    getMeasures
    |> countIncreases

let getPuzzle2Answer = 
    getMeasures
    |> List.windowed 3
    |> List.map List.sum
    |> countIncreases

printfn "Puzzle 1, part 1: %i" getPuzzle1Answer
printfn "Puzzle 1, part 2: %i" getPuzzle2Answer
