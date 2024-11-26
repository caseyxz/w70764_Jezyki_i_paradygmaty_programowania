module QuickSort

let rec quickSort list =
    match list with
    | [] -> []
    | pivot :: tail ->
        let left = List.filter (fun x -> x <= pivot) tail
        let right = List.filter (fun x -> x > pivot) tail
        quickSort left @ [pivot] @ quickSort right
