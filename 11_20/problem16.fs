(*
Problem 16
Power digit sum

2**15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

What is the sum of the digits of the number 2**1000?
*)
let strToInts (str: string) =
    // Cast string each element to char then int and use ASCII bindings to convert to numbers
    // Use 64-bit ints because error was overflowing before
    str |> Seq.map ( fun x -> (char >> int) x - 48 )

[<EntryPoint>]
let main args =
    pown (bigint 2) 1000
    |> string
    |> strToInts
    |> Seq.reduce (+)
    |> printfn "The sum of the digits of the number 2*1000 is %d"
    0
