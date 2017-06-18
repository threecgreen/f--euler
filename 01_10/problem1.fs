(*
Problem 1
Multiples of 3 and 5
Find the sum of all the multiples of 3 or 5 below 1000
*)
[<EntryPoint>]
let main args =
    [1 .. 999]
    |> List.filter (fun n -> (n % 5) * (n % 3) = 0)
    |> List.reduce (+)
    |> printfn "The sum of all multiples of 3 or 5 below 1000 is %d"
    0
