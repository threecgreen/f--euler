// Problem 5
// Smallest multiple
// What is the smallest positive number that is evenly divisible by all
// of the numbers from 1 to 20?
let notEvenlyDivisible number =
    let divisible = [11 .. 20] |> List.forall (fun divisor -> number % divisor = 0)
    not divisible

[<EntryPoint>]
let main args =
    let testSeq = {50 .. 427674624}
    let smallestNumber = testSeq |> Seq.takeWhile notEvenlyDivisible |> Seq.last
    // Stops with the number right before the correct answer
    printfn "The smallest number that is evenly divisible by all of the numbers from 1 to 20 is %d" (smallestNumber + 1)
    0