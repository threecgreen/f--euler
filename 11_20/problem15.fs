(*
Problem 15
Lattice paths

Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly
6 routes to the bottom right corner.

How many such routes are there through a 20×20 grid?
*)
let rec bigIntFactorial (number: bigint) =
    match number with
    // Matching doesn't work with biginst, use when
    | _ when number = 0I || number = 1I -> 1I
    | _ -> number * bigIntFactorial (number - 1I)

let latticeRoutes size =
    bigIntFactorial (size * 2I) / (pown (bigIntFactorial size) 2)

[<EntryPoint>]
let main args =
    latticeRoutes 20I
    |> printfn "The number of lattice paths is %A"
    0
