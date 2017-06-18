(*
Problem 30
Digit fifth powers

Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:

1634 = 1**4 + 6**4 + 3**4 + 4**4
8208 = 8**4 + 2**4 + 0**4 + 8**4
9474 = 9**4 + 4**4 + 7**4 + 4**4
As 1 = 1**4 is not a sum it is not included.

The sum of these numbers is 1634 + 8208 + 9474 = 19316.

Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
*)
/// Tests whether a number is the sum of its digits to the `power` power.
let isSumOfDigitsToPower power number =
    /// Change order of pown function for easier piping
    let revPown exp baseNum = pown baseNum exp
    number
    |> string
    |> Seq.map ( (fun x -> int x - 48) >> (revPown power ) )
    // |> Seq.map (pown numberOfDigits)
    |> Seq.reduce (+)
    |> (=) number

[<EntryPoint>]
let main args =
    [10..10000000]
    |> List.filter (isSumOfDigitsToPower 5)
    |> List.reduce (+)
    |> printfn "The sum of all numbers that are the sum of the fifth powers of their digits is %d"
    0