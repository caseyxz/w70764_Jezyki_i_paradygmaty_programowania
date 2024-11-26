// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

let x = 5
let y = "ala"
let mutable a = 14
a <- a + 1

printf "wartość liczby x: %d, twoje imię = %s" x y
printfn "\n Twoje imię: = %s" y

printfn "Podaj imię: " 
let name = System.Console.ReadLine() //czyta z input
printfn "\n Twoje imię: = %s" name

let x = 200
let y = 300

if x > y then
    printfn "x jest większe od y"
else
    printfn "x jest mniejsze od y"

let listaA = [1; 2; 3]
let listaB = 0:: listaA

for item in listaA do
    printfn "%d" item

let listaC = listaA @ listaB


    



