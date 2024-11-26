module Fbonacci

let rec fib n =
    if n <= 1 then n
    else fib (n - 1) + fib (n - 2)

let wynik = fib 4
printf "rek fib z 4: %d" wynik

let fibTail n =
    let rec aux n a b =
        if n = 0 then a
        else aux (n - 1) b (a + b)
    aux n 0 1

let wynikTail = fib 6
printf "rek fib z 6: %d" wynikTail