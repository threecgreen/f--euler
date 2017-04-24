// Problem 13
// Large Sum
// Work out the first ten digits of one-hundred 50-digit numbers
open System.IO

let firstTenDigits =
    let sumFiftyDigitNubmers =
        "fifty-digit-numbers.txt"
        |> File.ReadLines
        |> Seq.map bigint.Parse
        |> Seq.reduce (+)
        |> string
    sumFiftyDigitNubmers.[0..9]

[<EntryPoint>]
let main args =
    firstTenDigits |> printfn "The first ten digits of the sum of one-hundred 50-digit numbers is %s"
    0
