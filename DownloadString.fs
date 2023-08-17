open System
open System.Net

let downloadString (url : string) : string option =
    try
        use client = new WebClient()
        Some (client.DownloadString(url))
    with
    | :? System.Net.WebException as ex ->
        printfn "Error downloading URL: %s" ex.Message
        None

[<EntryPoint>]
let main argv =
    printfn "URL String Downloader"

    printfn "Enter the URL to download:"
    let url = Console.ReadLine()

    match downloadString url with
    | Some content -> printfn "Downloaded content:\n%s" content
    | None -> ()

    0 // return an integer exit code
