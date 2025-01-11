module ZmianaFormatuTekstu
open System

let przeksztalcFormatTekstu (wpis: string) =
    let dane = wpis.Split([| ';' |], StringSplitOptions.RemoveEmptyEntries)
    if dane.Length = 3 then
        let imie = dane.[0].Trim()
        let nazwisko = dane.[1].Trim()
        let wiek = dane.[2].Trim()
        printfn "%s, %s (%s lat)" nazwisko imie wiek
    else
        printfn "Niepoprawny format danych. Wprowadź dane w formacie 'imię; nazwisko; wiek'."


printfn "Podaj wpisy w formacie 'imię; nazwisko; wiek' (wpisz 'STOP' aby zakończyć):"
let mutable wpis = Console.ReadLine()
while wpis <> "STOP" do
    przeksztalcFormatTekstu wpis
    wpis <- Console.ReadLine()

