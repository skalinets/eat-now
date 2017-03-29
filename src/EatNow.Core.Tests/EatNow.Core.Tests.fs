module Tests

open Expecto

let (==?) a e = Expect.equal e a ""
let tests =
    test "simple test" {
       1 ==? 10    
    }

[<EntryPoint>]
let main argv =
    runTestsWithArgs defaultConfig argv tests 

