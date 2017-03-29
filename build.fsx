#r "packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.Testing.Expecto

let buildDir = "./build"
let testsDir = "./tests"

Target "Clean" (fun _ -> CleanDir buildDir)

Target "BuildApp" (fun _ -> 
        !! "src/**/*.fsproj"
            -- "src/**/*.Tests.fsproj"
            |> MSBuildRelease buildDir "Build"
            |> Log "AppBuild-Output: "
)

Target "BuildTests" (fun _ -> 
        printfn "hello %A" "you"
        !! "src/**/*.Tests.fsproj"
            |> MSBuildDebug testsDir "Build"
            |> Log "TestBuild-Output: "
)
let nunitRunnerPath = "./packages/NUnit.Runners/tools"

Target "RunUnitTests" (fun _ ->
        !! (testsDir + "/*.Tests.exe")
        |> Expecto (fun p -> p)

        printfn "hello"
)

"Clean"
    ==> "BuildApp"
    ==> "BuildTests"
    ==> "RunUnitTests"

RunTargetOrDefault "RunUnitTests"
