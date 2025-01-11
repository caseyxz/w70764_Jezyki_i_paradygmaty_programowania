module SystemBank

type BankAccount(accountNumber: string) =
    
    member val AccountNumber = accountNumber with get, set
    member val Balance = 0.0 with get, set

    
    member this.Deposit(amount: float) =
        if amount > 0.0 then
            this.Balance <- this.Balance + amount
        else
            printfn "Kwota do wpłaty musi być większa niż 0"

   
    member this.Withdraw(amount: float) =
        if amount > 0.0 then
            if amount <= this.Balance then
                this.Balance <- this.Balance - amount
            else
                printfn "Niewystarczające środki na koncie"
        else
            printfn "Kwota do wypłaty musi być większa niż 0"

type Bank() =
    
    let mutable accounts = []

    
    member this.CreateAccount(accountNumber: string) =
        let account = new BankAccount(accountNumber)
        accounts <- account :: accounts
        printfn "Konto o numerze %s zostało utworzone." accountNumber

    
    member this.GetAccount(accountNumber: string) =
        let account = accounts |> List.tryFind (fun acc -> acc.AccountNumber = accountNumber)
        match account with
        | Some(acc) -> Some(acc)
        | None -> 
            printfn "Konto o numerze %s nie istnieje." accountNumber
            None

    
    member this.UpdateAccount(accountNumber: string, newBalance: float) =
        let account = accounts |> List.tryFind (fun acc -> acc.AccountNumber = accountNumber)
        match account with
        | Some(acc) -> acc.Balance <- newBalance
        | None -> printfn "Konto o numerze %s nie istnieje." accountNumber

    
    member this.DeleteAccount(accountNumber: string) =
        accounts <- accounts |> List.filter (fun acc -> acc.AccountNumber <> accountNumber)
        printfn "Konto o numerze %s zostało usunięte." accountNumber

[<EntryPoint>]
let main argv =
    // Tworzymy instancję banku
    let bank = new Bank()

    // Tworzymy konta
    bank.CreateAccount("12345")
    bank.CreateAccount("67890")

    // Odczyt konta
    let account = bank.GetAccount("12345")
    match account with
    | Some(acc) -> printfn "Saldo konta %s: %.2f" acc.AccountNumber acc.Balance
    | None -> printfn "Nie znaleziono konta"

    // Wpłata na konto
    match account with
    | Some(acc) -> acc.Deposit(500.0)
    | None -> ()

    // Sprawdzamy saldo po wpłacie
    match account with
    | Some(acc) -> printfn "Saldo konta %s po wpłacie: %.2f" acc.AccountNumber acc.Balance
    | None -> printfn "Nie znaleziono konta"

    // Wypłata z konta
    match account with
    | Some(acc) -> acc.Withdraw(200.0)
    | None -> ()

    // Sprawdzamy saldo po wypłacie
    match account with
    | Some(acc) -> printfn "Saldo konta %s po wypłacie: %.2f" acc.AccountNumber acc.Balance
    | None -> printfn "Nie znaleziono konta"

    // Aktualizacja salda konta
    bank.UpdateAccount("12345", 1000.0)
    let updatedAccount = bank.GetAccount("12345")
    match updatedAccount with
    | Some(acc) -> printfn "Zaktualizowane saldo konta %s: %.2f" acc.AccountNumber acc.Balance
    | None -> printfn "Nie znaleziono konta"

    // Usuwanie konta
    bank.DeleteAccount("67890")

    // Próbujemy odczytać usunięte konto
    bank.GetAccount("67890") |> ignore

    0 
