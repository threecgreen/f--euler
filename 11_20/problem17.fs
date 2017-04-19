// Problem 17
// Number letter counts
(*
If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?

NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen)
contains 20 letters. The use of "and" when writing out numbers is in compliance with British usage.

fifteen sixteen
thirteen fourteen eighteen nineteen
seventeen

nine(4) hundred(7) and(3) seventy(7) three(5) = 26

forty fifty sixty
twenty thirty eighty ninety
seventy
*)

let rec numberLength number =
    let rec impl number length =
        match number with
        | 1000 -> 11
        // > 100
        // nine hundred(7)
        | _ when number % 100 = 0 -> impl (number / 100) 7
        // Integer division
        | _ when number > 100 -> impl ( number % 100 ) ( ( impl ( number / 100 ) length ) + 10 ) // hundred and
        // 20 < number < 100
        | 40 | 50 | 60 -> length + 5
        | 20 | 30 | 80 | 90 -> length + 6
        | 70 -> length + 7
        // Round to the nearest ten for getting tens digit and then calculate for remainder with recursion
        | _ when number > 20 -> impl ( number % 10 ) ( impl ( ( number / 10 ) * 10 ) length )
        // < 20
        | 1 | 2 | 6 | 10 -> length + 3
        | 4 | 5 | 9 -> length + 4
        | 3 | 7 | 8 -> length + 5
        | 11 | 12 -> length + 6
        | 15 | 16 -> length + 7
        | 13 | 14 | 18 | 19 -> length + 8
        | 17 -> length + 9
        // 0 -> 4
        | 0 when length = 0 -> 4
        | 0 -> length
    impl number 0

[<EntryPoint>]
let main args =
    [1 .. 1000]
    |> List.map numberLength
    |> List.reduce (+)
    |> printfn "The sum of the letters used for the numbers 1 to 1,000 inclusive is %d"
    0
