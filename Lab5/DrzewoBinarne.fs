module DrzewoBinarne

type TreeNode<'T> =
    | Empty
    | Node of 'T * TreeNode<'T> * TreeNode<'T>  

    // Funkcja rekurencyjna do wyszukiwania elementu w drzewie binarnym
let rec searchRecursive tree element =
    match tree with
    | Empty -> false  // Elementu nie ma w pustym drzewie
    | Node(value, left, right) ->
        if value = element then
            true  // Element znaleziony
        elif element < value then
            searchRecursive left element  // Szukamy w lewym poddrzewie
        else
            searchRecursive right element  // Szukamy w prawym poddrzewie

// Funkcja iteracyjna do wyszukiwania elementu w drzewie binarnym
let searchIterative tree element =
    let rec loop stack =
        match stack with
        | [] -> false  // Stos jest pusty, element nie został znaleziony
        | Empty :: _ -> loop stack.Tail  // Pusty węzeł, przechodzimy dalej
        | Node(value, left, right) :: tail ->
            if value = element then
                true  // Element znaleziony
            elif element < value then
                loop (left :: tail)  // Dodajemy lewe poddrzewo do stosu
            else
                loop (right :: tail)  // Dodajemy prawe poddrzewo do stosu

    loop [tree]  // Zaczynamy od korzenia drzewa

    // Tworzymy przykładowe drzewo binarne
let tree =
    Node(10,
        Node(5, Node(3, Empty, Empty), Node(7, Empty, Empty)),
        Node(15, Node(12, Empty, Empty), Node(20, Empty, Empty)))

// Testowanie funkcji rekurencyjnej
let resultRecursive = searchRecursive tree 7
printfn "Rekurencyjnie: Element znaleziony: %b" resultRecursive

// Testowanie funkcji iteracyjnej
let resultIterative = searchIterative tree 7
printfn "Iteracyjnie: Element znaleziony: %b" resultIterative
