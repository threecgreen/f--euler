(*
Problem 22
Name scores

Using names.txt, a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. Then
working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th
name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.

What is the total of all the name scores in the file?
*)
open System.IO

let alphabeticalValue (name: string) =
    name
    |> Seq.map (fun x -> (char >> int64) x - 64L)
    |> Seq.reduce (+)

let readFile (filename: string) =
    let text = File.ReadAllText filename
    let noNewlineText = text.Replace("\n", "")
    let noQuoteText = noNewlineText.Replace("\"", "")
    noQuoteText.Split [|','|]

[<EntryPoint>]
let main args =
    let names = readFile "p022_names.txt" |> Array.sort |> Array.map alphabeticalValue
    Array.map (fun n -> names.[n - 1] * (int64 n)) [|1..Array.length names|]
    |> Array.reduce (+)
    |> printfn "%d"
    0
