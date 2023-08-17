open System
open System.IO
open System.Runtime.Serialization.Formatters.Binary

// Define a sample class for demonstration
[<Serializable>]
type Person = { Name: string; Age: int }

let objectToByteArray (obj : 'T) : byte[] =
    use ms = new MemoryStream()
    let formatter = new BinaryFormatter()
    formatter.Serialize(ms, obj)
    ms.ToArray()

let byteArrayToObject (bytes : byte[]) : 'T =
    use ms = new MemoryStream(bytes)
    let formatter = new BinaryFormatter()
    ms.Seek(0L, SeekOrigin.Begin) |> ignore
    formatter.Deserialize(ms) :?> 'T

// Example usage
let person = { Name = "John"; Age = 30 }
let byteArray = objectToByteArray person
printfn "Object converted to byte array: %A" byteArray

let personFromByteArray = byteArrayToObject<Person> byteArray
printfn "Object reconstructed from byte array: %A" personFromByteArray
