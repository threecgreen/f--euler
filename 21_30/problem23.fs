// Problem 23
// Non-abundant sums
(*
A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For
example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a
perfect number.

A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant
if this sum exceeds n.

As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as
the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integers greater
than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced
any further by analysis even though it is known that the greatest number that cannot be expressed as the sum
of two abundant numbers is less than this limit.

Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
*)
let abundantNumbers =
    let isAbundant number =
        match number with
        | _ when number <= 1 -> false
        | _ ->
            [1 .. number / 2]
            |> List.filter (fun x -> number % x = 0)
            |> List.reduce (+)
            |> (<) number
    [1 .. 28123]
    |> List.filter isAbundant

let abundantSums =
    List.collect (fun i -> [ for j in abundantNumbers -> (i + j) ] ) abundantNumbers
    |> set

let notAbundantSumsSum =
    abundantSums - ( set [1 .. 28123] )
    |> seq
    |> Seq.reduce (+)

[<EntryPoint>]
let main args =
    notAbundantSumsSum
    |> printfn "The sum of all numbers that cannot be expressed as the sum of two abundant numbers is %d"
    0
