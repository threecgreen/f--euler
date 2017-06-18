(*
Problem 27
Quadratic primes

Euler discovered the remarkable quadratic formula:

n2 + n + 41n**2 + n + 41
It turns out that the formula will produce 40 primes for the consecutive integer values 0 ≤ n ≤ 39.
However, when n = 40, 40**2 + 40 + 41 = 40(40 + 1) + 41 is
divisible by 41, and certainly when n = 41, 41**2 + 41 + 41 is clearly divisible by 41.

The incredible formula n**2 − 79n + 1601 was discovered, which produces 80 primes for the consecutive
values 0 ≤ n ≤ 79. The product of the coefficients, −79 and 1601, is −126479.

Considering quadratics of the form:

n**2 + an + b, where |a| < 1000 and |b| ≤ 1000

where |n| is the modulus/absolute value of n
e.g. |11| = 11 and |−4| = 4
Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum
number of primes for consecutive values of n, starting with n = 0.
*)

/// Given two integers, creates a quadratic function of form: n**2 + an + b
let quadraticFactory a b =
    fun n -> ((pown n 2) + (a * n) + b)


/// Tests the number of primes produced by a given quadratic expression for consecutive values starting with 0
let consecutivePrimeCount (func: int -> int) =
    let isPrime number =
        let numSqrt = (float >> sqrt >> int) number
        // L appended to end of numbers ensures they are inferred as int64
        let testRange = [2 .. numSqrt]
        // No divisors
        testRange |> List.forall (fun x -> number % x <> 0)
    // Infinite test sequence of consecutive values starting with n = 0
    let infiniteSeq = Seq.unfold (fun n -> Some(n, (n + 1) ) ) 0
    infiniteSeq
    |> Seq.takeWhile (func >> isPrime)
    |> Seq.length


[<EntryPoint>]
let main args =
    List.collect (fun a -> [for b in -1000..1000 -> (a, b)]) [-999..999]
    |> seq
    |> Seq.map (fun (a, b) -> (quadraticFactory a b, a, b))
    |> Seq.map (fun (func, a, b) -> (consecutivePrimeCount func), a, b)
    |> Seq.maxBy (fun (primes, a, b) -> primes)
    |> (fun (primes, a, b) -> a * b)
    |> printfn "The product of the coefficients that produce the most consecutive primes is %d"
    0
