// Problem 12
// Highly divisible triangular number
// What is the value of the first triangle number to have over five hundred divisors?
let triangleNumbers = Seq.unfold (fun x-> Some (0.5 * x * (x + 1.0) |> (float >> int64), x + 1.0)) 1.0

let first500Divisor seq =
    let divisorCount number =
        [2L .. (float >> sqrt >> int64) number]
        |> List.filter (fun x -> number % x = 0L)
        |> List.length
        // Accompanying factor pair > sqrt (number)
        |> (fun x -> x * 2)
    seq |> Seq.find (fun x -> divisorCount x > 500)

[<EntryPoint>]
let main args =
    first500Divisor triangleNumbers
    // problem12
    |> printfn "The first triangle number to have over five hundred divisors is %d"
    0
