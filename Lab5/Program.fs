//for i = 1 to 5 do
//    printf "wartość i = %d" i

//for i = 5 downto 1 do
//    printf "wartość i = %d" i

//let mutable x = 0
//for x <= 5  do
//    printf "wartość i = %d" x <- x+1

//let rec sumaRec n =
//    if n <=0 then 0
//    else n + sumaRec(n-1)

//let sumaTail n = 
//    let rec sumaRecTail n acc = 
//        if n <=0 then acc
//        else n + sumaRecTail(n-1) (acc +n)
//    sumaRecTail n 0

let numbers = [1;2;3;4]
let numbers1 = List.map (fun x -> x *x) numbers
