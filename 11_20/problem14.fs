(*
Problem 14
Longest Collatz sequence

The following iterative sequence is defined for the set of positive integers:

n → n/2 (n is even)
n → 3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:

13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is
thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?
*)
let collatz n =
    let rec imp (x: int64) (i: int64) =
        match x, i with
        | 1L, _ -> n, i
        | _, _ when x % 2L = 0L -> imp (x / 2L) (i + 1L)
        | _, _ when x % 2L = 1L -> imp ( (3L * x) + 1L) (i + 1L)
    imp n 1L

let longestCollatzUnder number =
    [ 1L .. (number - 1L) ]
    |> List.map collatz
    // Calculate maximum by the second value of the tuple
    |> List.maxBy snd

[<EntryPoint>]
let main args =
    let longestCollatz, sequenceLength = longestCollatzUnder 1000000L
    printfn "The largest collatz sequence for numbers under 1000000 is %d with a length of %d" longestCollatz sequenceLength
    0
