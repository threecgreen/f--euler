(*
Problem 24
Lexicographic permutations

A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation
of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically,
we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:

012   021   102   120   201   210

What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
*)
module Euler.P24

let nonZeroStringDigits = [1..9] |> List.map string
let stringDigits = [0..9] |> List.map string

let containsAllDigits (s : string) =
    let digits =
        match s.Length with
        | 9 -> nonZeroStringDigits
        | _ -> stringDigits
    digits |> List.forall (fun d -> s.Contains(d))

let lexographicPermutations =
    Seq.map string
    >> Seq.filter containsAllDigits

let solution() =
    {123_456_789L..9_876_543_210L} |> lexographicPermutations
    |> Seq.skip 999_999
    |> Seq.head
    |> printfn "The millionth permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 is %s"
