module WieżaHanoi

let rec hanoi n source target auxiliary =
    if n = 1 then
        printfn "Przenieś dysk z %s do %s" source target
    else
        hanoi (n - 1) source auxiliary target
        printfn "Przenieś dysk z %s do %s" source target
        hanoi (n - 1) auxiliary target source
