module Palidromy

open System

let czyPalindrom (tekst: string) =
    let tekstBezSpacji = tekst.Replace(" ", "").ToLower()
    let odwroconyTekst = new string(Array.rev (tekstBezSpacji.ToCharArray()))
    if tekstBezSpacji = odwroconyTekst then
        printfn "Podany tekst jest palindromem."
    else
        printfn "Podany tekst nie jest palindromem."


printf "Podaj tekst do sprawdzenia: "
let tekst = Console.ReadLine()
czyPalindrom tekst
