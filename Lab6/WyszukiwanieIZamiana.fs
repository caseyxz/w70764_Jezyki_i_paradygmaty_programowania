module WyszukiwanieIZamiana

open System

let zamienSlowo (tekst: string) (szukaneSlowo: string) (noweSlowo: string) =
    let zmodyfikowanyTekst = tekst.Replace(szukaneSlowo, noweSlowo)
    printfn "Zmodyfikowany tekst: %s" zmodyfikowanyTekst

printf "Podaj tekst: "
let tekst = Console.ReadLine()

printf "Podaj słowo do wyszukania: "
let szukaneSlowo = Console.ReadLine()

printf "Podaj słowo na które chcesz zamienić: "
let noweSlowo = Console.ReadLine()

zamienSlowo tekst szukaneSlowo noweSlowo