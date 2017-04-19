// Problem 2
// Even Fibonacci numbers
// By considering the terms in the Fibonacci sequence whose values do not
// exceed four million, find the sum of the even-valued terms

// generate an infinite Fibonacci sequence
let fibonacciSeq = Seq.unfold (fun (a,b) -> Some( a+b, (b, a+b) ) ) (0,1)

let isEven num = (num % 2 = 0)

let sumOfEvenFibonacci =
    fibonacciSeq |> Seq.takeWhile (fun x -> x <= 4000000) |> Seq.filter isEven |> Seq.reduce (+)

[<EntryPoint>]
let main args =
    printfn "The sum of the even terms of the Fibonacci sequence whose values do not exceed four million is %d" sumOfEvenFibonacci
    0
