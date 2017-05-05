// Problem 2
// Even Fibonacci numbers
// By considering the terms in the Fibonacci sequence whose values do not
// exceed four million, find the sum of the even-valued terms

/// generate an infinite Fibonacci sequence
let fibonacciSeq = Seq.unfold (fun (a,b) -> Some( a+b, (b, a+b) ) ) (0,1)

/// Finds sum of even fibonacci numbers that don't exceed `max` parameter
let sumOfEvenFibonacci max =
    fibonacciSeq
    |> Seq.takeWhile (fun x -> x <= max)
    |> Seq.filter (fun n -> n % 2 = 0)
    |> Seq.reduce (+)

[<EntryPoint>]
let main args =
    sumOfEvenFibonacci 4000000
    |> printfn "The sum of the even terms of the Fibonacci sequence whose values do not exceed four million is %d"
    0
