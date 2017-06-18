(*
Problem 21
Amicable numbers

Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

Evaluate the sum of all the amicable numbers under 10000.
*)
let sumOfProperDivisors number =
    match number with
    | 0 | 1 -> 0
    | _ when number > 1 ->
        [1 .. (number / 2)]
        |> List.filter (fun div -> number % div = 0)
        |> List.reduce (+)

let amicablePairs range =
    let testRange = List.map (fun n -> (n, sumOfProperDivisors n)) range
    List.map (fun n -> (n, sumOfProperDivisors n)) range
    // Check if the sum of proper divisors equals another number in the range, the number equals a the sum of the proper divisors of another number and the number and its sum of
    // proper divisors are not the same
    |> List.filter ( fun (n, sum) -> List.exists (fun (n2, sum2) -> n2 = sum && n = sum2 && n <> sum) testRange )
    |> List.map (fun (n, sum) -> n)

[<EntryPoint>]
let main args =
    amicablePairs [3..9999]
    |> List.reduce (+)
    |> printfn "The sum of all amicable pairs under 10000 is %d."
    0
