type Direction =
    | Vertical
    | Horizontal
    | Unknown

type Move = {
    Direction: Direction
    Value: int        
}

let ParseMoveDescription (text: string) =
    let textParts = text.Split [|' '|]
    
    let value = int textParts[1]
    let direction = 
        match textParts[0] with
            | "forward" -> Direction.Horizontal
            | "down" | "up" -> Direction.Vertical
            | _ -> Direction.Unknown

    {   Direction = direction;
        Value = if textParts[0] = "up" then value * -1 else value }

module Puzzle1 =
    let GetMovesInDirection direction moves =
        moves
        |> List.filter (fun move -> move.Direction = direction)
    
    let SumMovements moves = 
        moves
        |> List.sumBy (fun move -> move.Value)
    
    let SumHorizontalMoves moves =
        moves
        |> GetMovesInDirection Direction.Horizontal
        |> SumMovements
    
    let SumVerticalMoves moves =
        moves
        |> GetMovesInDirection Direction.Vertical
        |> SumMovements

    let GetAnswer =
        Common.getInputs
        |> List.map ParseMoveDescription
        |> function moves -> (SumVerticalMoves moves) * (SumHorizontalMoves moves)

module Puzzle2 =
    type Position = {
        Horizontal: int
        Depth: int
        Aim: int
    }

    let ApplyMove state move =
        let horizontalChange = 
            match move.Direction with
                | Direction.Horizontal -> move.Value
                | _ -> 0
    
        let depthChange = 
            match move.Direction with
                | Direction.Horizontal -> move.Value * state.Aim
                | _ -> 0
    
        let aimChange = 
            match move.Direction with
                | Direction.Vertical -> move.Value
                | _ -> 0
    
        {   Horizontal = state.Horizontal + horizontalChange;
            Depth = state.Depth + depthChange;
            Aim = state.Aim + aimChange }

    let GetAnswer =
        Common.getInputs
        |> List.map ParseMoveDescription
        |> List.fold ApplyMove { Horizontal = 0; Depth = 0; Aim = 0 }
        |> function finalPosition -> finalPosition.Horizontal * finalPosition.Depth

printfn "Puzzle 1: %i" Puzzle1.GetAnswer
printfn "Puzzle 2: %i" Puzzle2.GetAnswer