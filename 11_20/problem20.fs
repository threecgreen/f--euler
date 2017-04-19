// Problem 20
// Factorial digit sum
(*
n! means n × (n − 1) × ... × 3 × 2 × 1

For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

Find the sum of the digits in the number 100!
*)
let fac (number: int) =
    let rec impl number total =
        match number with
        | _ when number = bigint.One -> total
        | _ -> impl (number - bigint.One) (total * number)
    impl (bigint number) bigint.One

let strToInts (str: string) =
    // Cast string each element to char then int and use ASCII bindings to convert to numbers
    // Use 64-bit ints because error was overflowing before
    str |> Seq.map ( fun x -> (char >> int) x - 48 )

[<EntryPoint>]
let main args =
    100
    |> fac
    |> string
    |> strToInts
    |> Seq.reduce (+)
    |> printfn "The sum of the digits in 100! is %d"
    0
