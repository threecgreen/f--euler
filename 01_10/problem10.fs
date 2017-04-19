// Problem 10
// Summation of primes
// Find the sum of all the primes below two million
let isPrime (number: int64) =
    /// Tests whether a given number is prime
    /// Currently returns true for 1
    let numSqrt = (float >> sqrt >> int64) number
    // L appended to end of numbers ensures they are inferred as int64
    let testRange = [2L .. numSqrt]
    // No divisors
    testRange |> List.forall (fun x -> number % x <> 0L)

let sumOfPrimesLessThan (number: int64) =
    // 1 is not prime
    [2L .. number - 1L]
    |> List.filter isPrime
    |> List.reduce (+)

[<EntryPoint>]
let main args =
    2000000L
    |> sumOfPrimesLessThan
    |> printfn "The sum of all the primes below two million is %d"
    0
