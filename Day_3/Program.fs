let CharToInt (char: char) =
    int char - int '0'

let StringCharToInt (text: string) index =
    CharToInt text[index]

let BinaryListToInteger binaryList =
    (List.foldBack 
        (fun bit accumulator -> 
            {|  ConvertedInt = accumulator.ConvertedInt + bit * accumulator.BitWeight
                BitWeight = accumulator.BitWeight * 2 |})
        binaryList
        {| BitWeight = 1; ConvertedInt = 0 |}
    ).ConvertedInt
    
let BinaryStringToInteger (binaryString: string) =
    binaryString.ToCharArray()
    |> Array.map CharToInt
    |> Array.toList
    |> BinaryListToInteger

module Puzzle1 =
    let AddBinaryStringToCount (bitCounts: int list) (binaryString: string) =
        bitCounts
        |> List.mapi (fun index count -> count + (StringCharToInt binaryString index))

    let CountPositiveBits binaryStrings =
        List.fold AddBinaryStringToCount (List.init 12 (fun _ -> 0)) binaryStrings

    let GetOppositeBinaryList binaryList =
        List.map (fun bit -> 1 - bit) binaryList

    let GetGammaRateBinaryList binaryStrings =
        binaryStrings
        |> CountPositiveBits
        |> List.map (fun bitSum -> 
            match bitSum with
            | count when count > (binaryStrings.Length / 2) -> 1
            | _ -> 0
        )

    let GetGammaRateFromBinaryList binaryList =
        BinaryListToInteger binaryList

    let GetEpsilonRateFromGammaRateBinaryList gammaRateBinaryList =
        GetOppositeBinaryList gammaRateBinaryList
        |> BinaryListToInteger

    let GetAnswer = 
        let gammaRateBinaryList =
            Common.getInputs
            |> GetGammaRateBinaryList

        (GetGammaRateFromBinaryList gammaRateBinaryList) * (GetEpsilonRateFromGammaRateBinaryList gammaRateBinaryList)

module Puzzle2 =
    let GetLongestList (list1: 'a list) (list2: 'a list) =
        match list1 with
        | _ when list1.Length >= list2.Length -> list1
        | _ -> list2

    let GetShortestList (list1: 'a list) (list2: 'a list) =
        match list1 with
        | _ when list1.Length <= list2.Length -> list1
        | _ -> list2

    let rec FindByBitCriteriaAtIndex partitioningPredicate partitioningResultSelector bitIndex (binaryStrings: string list) =
        let maxStringIndex = binaryStrings[0].Length - 1
        
        binaryStrings
        |> List.partition (fun item -> partitioningPredicate bitIndex item)
        ||> partitioningResultSelector
        |> function
            | [ oxygenRating ] -> oxygenRating
            | list when bitIndex < maxStringIndex -> FindByBitCriteriaAtIndex partitioningPredicate partitioningResultSelector (bitIndex + 1) list
            | _ -> "not found"
        
    let FindOxygenRatingBinaryString (binaryStrings: string list) =
        FindByBitCriteriaAtIndex (fun bitIndex binaryString -> binaryString[bitIndex] = '1') GetLongestList 0 binaryStrings
        |> BinaryStringToInteger

    let FindCarbonDioxydeRatingBinaryString (binaryStrings: string list) =
        FindByBitCriteriaAtIndex (fun bitIndex binaryString -> binaryString[bitIndex] = '0') GetShortestList 0 binaryStrings
        |> BinaryStringToInteger

    let GetAnswer =
        Common.getInputs
        |> function inputs -> FindOxygenRatingBinaryString inputs * FindCarbonDioxydeRatingBinaryString inputs


printfn "Puzzle 1: %i" Puzzle1.GetAnswer
printfn "Puzzle 2: %A" Puzzle2.GetAnswer