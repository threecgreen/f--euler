// Problem 4
// Largest palindrome product
// Find the largest palindrome made from the product of two 3-digit numbers
let isPalindrome number =
    let str = string number
    let rec impl indexA indexB =
        indexA >= indexB || (str.[indexA] = str.[indexB] && impl (indexA + 1) (indexB - 1))
    impl 0 (str.Length - 1)

let largestPalindrome =
    // Cast to sequence to eliminate duplicates
    let productsOfThreeDigits = List.collect (fun x -> [for i in 100 .. 999 -> x * i]) [100 .. 999] |> seq
    productsOfThreeDigits
    |> Seq.filter isPalindrome
    |> Seq.max

[<EntryPoint>]
let main args =
    printfn "The largest palindrome made from the product of two 3-digit numbers is %d" largestPalindrome
    0
