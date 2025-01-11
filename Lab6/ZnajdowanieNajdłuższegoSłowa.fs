module ZnajdowanieNajdłuższegoSłowa

open System

let znajdzNajdluzszeSlowo (tekst: string) =
    let slowa = tekst.Split([| ' '; '\t'; '\n' |], StringSplitOptions.RemoveEmptyEntries)
    let najdluzszeSlowo = slowa |> Array.maxBy (fun s -> s.Length)
    printfn "Najdłuższe słowo: '%s'" najdluzszeSlowo
    printfn "Długość najdłuższego słowa: %d" najdluzszeSlowo.Length


printf "Podaj tekst: "
let tekst = Console.ReadLine()
znajdzNajdluzszeSlowo tekst
