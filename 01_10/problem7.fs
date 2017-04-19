// Problem 7
// 10001st prime
// What is the 10,001st prime number?
let isPrime (number: int64) =
    match number with
    | _ when number <= 1L -> false
    | _ -> (
            let numSqrt = (float >> sqrt >> int64) number
            let testRange = [2L .. numSqrt]
            testRange |> List.forall (fun x -> number % x <> 0L)
        )

let rec nextPrime n =
    match (isPrime n) with
    | true -> n
    | false -> nextPrime (n + 1L)

let primes = Seq.unfold ( fun x -> Some ( x, nextPrime (x + 1L) ) ) 2L

[<EntryPoint>]
let main args =
    primes
    // Indexing begins at 0
    |> Seq.item 10000
    |> printfn "The 10001st prime is %d"
    0
