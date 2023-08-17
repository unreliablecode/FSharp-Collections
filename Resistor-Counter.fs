open System

let calculateParallelResistance (resistances : float array) : float =
    1.0 / Array.sumBy (fun r -> 1.0 / r) resistances

let calculateSeriesResistance (resistances : float array) : float =
    Array.sum resistances

let readResistorValues (count : int) : float array =
    let mutable resistors = Array.zeroCreate count
    for i = 0 to count - 1 do
        printfn "Enter resistance value for resistor %d (Ohms):" (i + 1)
        let input = Console.ReadLine()
        match Double.TryParse(input) with
        | true, value -> resistors.[i] <- value
        | _ ->
            printfn "Invalid input. Please enter a valid resistance value."
            i <- i - 1
    resistors

[<EntryPoint>]
let main argv =
    printfn "Resistor Calculation Program"

    printfn "Enter the number of resistors in series:"
    let seriesCount = int(Console.ReadLine())

    printfn "Enter the number of resistors in parallel:"
    let parallelCount = int(Console.ReadLine())

    let seriesResistances = readResistorValues seriesCount
    let parallelResistances = readResistorValues parallelCount

    let totalSeriesResistance = calculateSeriesResistance seriesResistances
    let totalParallelResistance = calculateParallelResistance parallelResistances

    printfn "Total resistance in series: %.2f Ohms" totalSeriesResistance
    printfn "Total resistance in parallel: %.2f Ohms" totalParallelResistance

    0 // return an integer exit code
