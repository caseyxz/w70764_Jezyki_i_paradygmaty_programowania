module LiczbaSłówiZnaków

//Zadanie 1. Liczba słów i znaków
//Napisz program, który pobiera tekst od użytkownika, a następnie oblicza i wyświetla:
//• Liczbę słów w podanym tekście.
//• Liczbę znaków (bez spacji).

open System

let obliczLiczbeSlowIZnakow (tekst: string) =
    let slowa = tekst.Split([| ' '; '\t'; '\n' |], StringSplitOptions.RemoveEmptyEntries)
    let liczbaSlow = slowa.Length
    let liczbaZnakow = tekst.Replace(" ", "").Length
    printfn "Liczba słów: %d" liczbaSlow
    printfn "Liczba znaków (bez spacji): %d" liczbaZnakow


printf "Podaj tekst: "
let tekst = Console.ReadLine()
obliczLiczbeSlowIZnakow tekst