module PermutacjaListy

let rec permute list =
    let insertAtAllPositions x xs =
        [ for i in 0 .. List.length xs -> xs.[0..i-1] @ [x] @ xs.[i..] ]
    match list with
    | [] -> [[]]
    | x :: xs -> List.collect (insertAtAllPositions x) (permute xs)
