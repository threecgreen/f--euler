// Problem 6
// Sum square difference
// Find the difference between the sum of the squares of the first one hundred
// natural numbers and the square of the sum.
let sumOfSquares range =
    range |> List.map (fun x -> x * x) |> List.reduce (+)

let squareOfSum range =
    range |> List.reduce (+) |> (fun x -> x * x)

[<EntryPoint>]
let main args =
    let difference = abs ( sumOfSquares [1 .. 100] ) - ( squareOfSum [1 .. 100] )
    printfn "The difference between the sum of the squares and the square of the sum of the first 100 natural numbers is %d" difference
    0
