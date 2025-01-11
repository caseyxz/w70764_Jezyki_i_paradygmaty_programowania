module Usuwanieduplikatów

open System
open System.Collections.Generic

let usunDuplikaty lista =
    lista |> List.distinct


printf "Podaj słowa oddzielone spacjami: "
let tekst = Console.ReadLine()
let slowa = tekst.Split([| ' ' |], StringSplitOptions.RemoveEmptyEntries) |> List.ofArray


let unikalneSlowa = usunDuplikaty slowa
printfn "Unikalne słowa: %A" unikalneSlowa
