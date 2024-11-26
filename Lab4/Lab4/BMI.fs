module BMI

open System

type User = {
    Weight: float
    Height: float
}


let calculateBMI (user: User) =
    let heightMeters = user.Height / 100.0 
    user.Weight / (heightMeters ** 2.0)    


let bmiCategory bmi =
    match bmi with
    | x when x < 18.5 -> "Niedowaga"
    | x when x < 24.9 -> "Waga prawidłowa"
    | x when x < 29.9 -> "Nadwaga"
    | _ -> "Otyłość"


[<EntryPoint>]
let main argv =
 
    printfn "Podaj wagę w kilogramach:"
    let weightInput = Console.ReadLine() |> float

    printfn "Podaj wzrost w centymetrach:"
    let heightInput = Console.ReadLine() |> float

    
    let user = { Weight = weightInput; Height = heightInput }

  
    let bmi = calculateBMI user
    let category = bmiCategory bmi

      
    printfn "Twoje BMI wynosi: %.2f" bmi
    printfn "Kategoria BMI: %s" category

    0 


