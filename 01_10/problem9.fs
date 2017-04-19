// Problem 9
// Special Pythagorean triplet
// There exists exactly one Pythagorean triplet for which a + b + c = 1000
// Find the product abc

let pythagoreanTriple =
    List.collect (fun i -> [for j in 1 .. 999 -> i, j, 1000 - i - j ]) [1 .. 999]
    |> List.find (fun (i, j, k) -> i * i + j * j = k * k )

[<EntryPoint>]
let main args =
    pythagoreanTriple
    |> (fun (i, j, k) -> i * j * k)
    |> printfn "The product of abc is %d"
    0