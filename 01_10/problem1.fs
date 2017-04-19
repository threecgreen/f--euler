// Problem 1
// Multiples of 3 and 5
// Find the sum of all the multiples of 3 or 5 below 1000

let is3Or5Multiple num =
    /// Returns the number if it is a multiple of 3 or 5, otherwise it returns 0
    match (num % 5) * (num % 3) with
    | 0 -> num
    | _ -> 0

[<EntryPoint>]
let main args =
    let allNums = [1 .. 999]
    let multiples = allNums |> List.map is3Or5Multiple
    let sum = List.sum multiples
    printfn "The sum of all multiples of 3 or 5 below 1000 is %d" sum
    0
