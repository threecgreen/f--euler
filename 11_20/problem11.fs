(*
Problem 11
Largest product in a grid

In the 20×20 grid below, four numbers along a diagonal line have been marked in red.

The product of these numbers is 26 × 63 × 78 × 14 = 1788696.

What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?
*)
open System.IO

let readFile filename =
    File.ReadAllLines filename
    // Split on spaces
    |> Array.map (fun line -> line.Split [|' '|])
    |> Array.map (Array.map int)

let verticalProduct (grid: int[][]) x y =
    grid.[y].[x] * grid.[y + 1].[x] * grid.[y + 2].[x] * grid.[y + 3].[x]

let horizontalProduct (grid: int[][]) x y =
    let row = grid.[y]
    row.[x] * row.[x + 1] * row.[x + 2] * row.[x + 3]

let topDownDiagonalProduct (grid: int[][]) x y =
    grid.[y].[x] * grid.[y + 1].[x + 1] * grid.[y + 2].[x + 2] * grid.[y + 3].[x + 3]

let bottomUpDiagonalProduct (grid: int[][]) x y =
    let l = Array.length grid
    // Use subtraction in indexing to match other functions to allow easier mapping
    grid.[l - y - 1].[x] * grid.[l - y - 2].[x + 1] * grid.[l - y - 3].[x + 2] * grid.[l - y - 4].[x + 3]

let adjacentProducts numAdjacent (grid: int[][])  =
    let maxIndex = Array.length grid - numAdjacent - 1
    // let testCoordinates = List.collect (fun i -> [for j in 0..16 -> (i, j)]) [0..16]
    [verticalProduct; horizontalProduct; topDownDiagonalProduct; bottomUpDiagonalProduct]
    |> List.map (fun product -> List.collect (fun i -> [for j in 0..maxIndex -> product grid i j]) [0..maxIndex] )
    // Flatten lists
    |> List.reduce (@)

[<EntryPoint>]
let main args =
    readFile "20x20-grid.txt"
    |> adjacentProducts 4
    |> List.max
    |> printfn "The maximum product of four adjacent numbers is %d"
    0