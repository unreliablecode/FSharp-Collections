open System

let isEven number =
    number % 2 = 0

let isOdd number =
    not (isEven number)

let rec mainLoop () =
    printf "Enter a number: "
    let input = Console.ReadLine()

    match Int32.TryParse(input) with
    | true, number ->
        if isEven number then
            printf "%d is even.\n" number
        else
            printf "%d is odd.\n" number
        mainLoop ()
    | _ ->
        printf "Invalid input. Please enter a valid number.\n"
        mainLoop ()

[<EntryPoint>]
let main argv =
    printfn "Even and Odd Number Detector (Press Ctrl+C to exit)\n"
    mainLoop ()
    0 // return an integer exit code
