(*
Problem 19
Counting sundays

You are given the following information, but you may prefer to do some research for yourself.

1 Jan 1900 was a Monday.
Thirty days has September,
April, June and November.
All the rest have thirty-one,
Saving February alone,
Which has twenty-eight, rain or shine.
And on leap years, twenty-nine.
A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
*)
open System

let firstOfMonthSundays yearRange =
    yearRange
    |> List.collect (fun year -> [1..12] |> List.map (fun month -> DateTime(year, month, 1) ) )
    |> List.filter (fun date -> date.DayOfWeek = DayOfWeek.Sunday)
    |> List.length

[<EntryPoint>]
let main args =
    [1901..2000]
    |> firstOfMonthSundays
    |> printfn "The number of Sundays that fell on the first of the month in the 20th century is %d"
    0
