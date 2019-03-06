namespace fsharp_benchmarks

open System
open UnityEngine
open NoMutateBenchmarks

type FSLib() = 
        let mutable testsStarted = false
        
        let iterativeBenchmark msg func iterations minTime =
            let mutable count = 1
            let mutable runningTime = 0.0
            let mutable deltaTime = 0.0
            let mutable deltaTimeSquared = 0.0
            
            while (runningTime < minTime && count < Int32.MaxValue / 2) do
                count <- count * 2
                deltaTime <- 0.0
                deltaTimeSquared <- 0.0 
                for j in 0 .. iterations do
                    let started = DateTime.UtcNow
                    for i in 0 .. count do
                        func i |> ignore
                    runningTime <- DateTime.UtcNow.Subtract(started).TotalMilliseconds * 1000000.0
                    let time = runningTime / float count
                    deltaTime <- deltaTime + time
                    deltaTimeSquared <- deltaTimeSquared + time * time
            let mean = deltaTime / float iterations
            let standardDeviation = sqrt (abs (deltaTimeSquared - mean * mean * float iterations) / float (iterations - 1))
            printfn "%s,%f,%f,%i" msg mean standardDeviation count
            msg, mean, standardDeviation, count
            
        member x.FStart() =
            Debug.Log "Ready from F#!" 
            2
            
           
        member x.benchmarkRunner() =
            if Input.GetKeyDown KeyCode.Space && not testsStarted then 
                Debug.Log "Starting tests"
                testsStarted <- true
                let iterations = 5
                let minTime = float32 (250 * 1000000)
                let mutable results = []
                
                let runBenchmark bench msg func = bench msg func iterations minTime
                let (<<) l r = results <- results @ [ r ]
                
                
                printfn "Iterative Mark8 benchmark"
                results << runBenchmark iterativeBenchmark "ScaleVector2D" scaleVector2D  
                results << runBenchmark iterativeBenchmark "ScaleVector3D" scaleVector3D 
                results << runBenchmark iterativeBenchmark "MultiplyVector2D" multiplyVector2D
                results << runBenchmark iterativeBenchmark "MultiplyVector3D" multiplyVector3D
                results << runBenchmark iterativeBenchmark "TranslateVector2D" translateVector2D  
                results << runBenchmark iterativeBenchmark "TranslateVector3D" translateVector3D
                results << runBenchmark iterativeBenchmark "SubtractVector2D" subtractVector2D
                results << runBenchmark iterativeBenchmark "SubtractVector3D" subtractVector3D
                results << runBenchmark iterativeBenchmark "LengthVector2D" lengthVector2D
                results << runBenchmark iterativeBenchmark "LengthVector3D" lengthVector3D
                results << runBenchmark iterativeBenchmark "DotProductVector2D" dotProductVector2D  
                results << runBenchmark iterativeBenchmark "DotProductVector3D" dotProductVector3D
                
                Debug.Log "Done with tests"
            0

