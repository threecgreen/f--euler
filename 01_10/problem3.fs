// Problem 3
// Largest prime factor
// What is the largest prime factor of the number 600851475143?
/// Tests whether a given number is prime
let isPrime (number: int64) =
    let numSqrt = (float >> sqrt >> int64) number
    // L appended to end of numbers ensures they are inferred as int64
    let testRange = [2L .. numSqrt]
    // No divisors
    testRange |> List.forall (fun x -> number % x <> 0L)

/// Assumes odd number, finds the largest prime factor of the given number
let getMaxPrimeFactor (number: int64) =
    let rec getMaxPrimeFactor' testFactor =
        match isPrime testFactor && (number % testFactor = 0L) with
        // Return testFactor
        | true -> testFactor
        // Recursively try for second next largest number (is odd)
        | false -> getMaxPrimeFactor' (testFactor - 2L)
    let numSqrt = (float >> sqrt >> int64) number
    let start = if numSqrt % 2L = 0L then numSqrt + 1L else numSqrt
    getMaxPrimeFactor' start

/// Finds the largest prime factor of the number 600,851,475
[<EntryPoint>]
let main args =
    let maxPrimeFactor = getMaxPrimeFactor 600851475143L
    printfn "The largest prime factor of the number 600851475143 is %d" maxPrimeFactor
    0