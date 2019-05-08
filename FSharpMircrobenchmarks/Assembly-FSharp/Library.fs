module Run
open System
open GameOfLife
open NumericalBenchmarks
open InvasionPercolation
open MapReduce
open SestoftBenchmark
open UnityEngine


let start () =
    let p = 10
    
    
    let iterations = 5
    let minTime = float (250 * 1000000)
    let mutable results = []
    let (<<) l r = results <- results @ [ r ]
    
    let runBenchmark msg func = Benchmark.Mark8 (msg, (new Func<int, float32>(func)), iterations, minTime)
    let toString resultTuple =
        let struct(name, mean, dev, count, dummy) = resultTuple
        sprintf "%s,%.3f,%.3f,%i" name mean dev count

    printfn "Iterative Mark8 benchmark"
    
    
    results << runBenchmark "MapReduce Array" mapReduceArray
    results << runBenchmark "MapReduce Array" mapReduceArray
    results << runBenchmark "MapReduce Array" mapReduceArray
    results << runBenchmark "MapReduce Array" mapReduceArray
    results << runBenchmark "MapReduce Array" mapReduceArray
    
    results << runBenchmark "MapReduce Seq" mapReduceSeq
    results << runBenchmark "MapReduce Seq" mapReduceSeq
    results << runBenchmark "MapReduce Seq" mapReduceSeq
    results << runBenchmark "MapReduce Seq" mapReduceSeq
    results << runBenchmark "MapReduce Seq" mapReduceSeq
    
    results << runBenchmark "MapReduce Unions" mapReduceUnions
    results << runBenchmark "MapReduce Unions" mapReduceUnions
    results << runBenchmark "MapReduce Unions" mapReduceUnions
    results << runBenchmark "MapReduce Unions" mapReduceUnions
    results << runBenchmark "MapReduce Unions" mapReduceUnions
    
    results << runBenchmark "Sestoft Multiply" multiply
    results << runBenchmark "Sestoft Multiply" multiply
    results << runBenchmark "Sestoft Multiply" multiply
    results << runBenchmark "Sestoft Multiply" multiply
    results << runBenchmark "Sestoft Multiply" multiply
    
    results << runBenchmark "Primes" (primes 100)
    results << runBenchmark "Primes" (primes 100)
    results << runBenchmark "Primes" (primes 100)
    results << runBenchmark "Primes" (primes 100)
    results << runBenchmark "Primes" (primes 100)
    
    results << runBenchmark "RandomizeArray" (randomizeArray 4 4)
    results << runBenchmark "RandomizeArray" (randomizeArray 4 4)
    results << runBenchmark "RandomizeArray" (randomizeArray 4 4)
    results << runBenchmark "RandomizeArray" (randomizeArray 4 4)
    results << runBenchmark "RandomizeArray" (randomizeArray 4 4)
    
    results << runBenchmark "GameOfLife" (iterateGameOfLifeTimes 4)
    results << runBenchmark "GameOfLife" (iterateGameOfLifeTimes 4)
    results << runBenchmark "GameOfLife" (iterateGameOfLifeTimes 4)
    results << runBenchmark "GameOfLife" (iterateGameOfLifeTimes 4)
    results << runBenchmark "GameOfLife" (iterateGameOfLifeTimes 4)
    
    results << runBenchmark "InvasionPercolation" (invPercoBenchmark 5 10)
    results << runBenchmark "InvasionPercolation" (invPercoBenchmark 5 10)
    results << runBenchmark "InvasionPercolation" (invPercoBenchmark 5 10)
    results << runBenchmark "InvasionPercolation" (invPercoBenchmark 5 10)
    results << runBenchmark "InvasionPercolation" (invPercoBenchmark 5 10)
    
    results << runBenchmark "FibonacciRecursive" (fibRecWrap 150)
    results << runBenchmark "FibonacciRecursive" (fibRecWrap 150)
    results << runBenchmark "FibonacciRecursive" (fibRecWrap 150)
    results << runBenchmark "FibonacciRecursive" (fibRecWrap 150)
    results << runBenchmark "FibonacciRecursive" (fibRecWrap 150)
    
    results << runBenchmark "FibonacciIterative" (fibIterWrap 150)
    results << runBenchmark "FibonacciIterative" (fibIterWrap 150)
    results << runBenchmark "FibonacciIterative" (fibIterWrap 150)
    results << runBenchmark "FibonacciIterative" (fibIterWrap 150)
    results << runBenchmark "FibonacciIterative" (fibIterWrap 150)
    
    results << runBenchmark "ScaleVector2D" MutateBenchmarks.scaleVector2D
    results << runBenchmark "ScaleVector2D" MutateBenchmarks.scaleVector2D
    results << runBenchmark "ScaleVector2D" MutateBenchmarks.scaleVector2D
    results << runBenchmark "ScaleVector2D" MutateBenchmarks.scaleVector2D
    results << runBenchmark "ScaleVector2D" MutateBenchmarks.scaleVector2D
    
    results << runBenchmark "ScaleVector3D" MutateBenchmarks.scaleVector3D 
    results << runBenchmark "ScaleVector3D" MutateBenchmarks.scaleVector3D 
    results << runBenchmark "ScaleVector3D" MutateBenchmarks.scaleVector3D 
    results << runBenchmark "ScaleVector3D" MutateBenchmarks.scaleVector3D 
    results << runBenchmark "ScaleVector3D" MutateBenchmarks.scaleVector3D
    
    results << runBenchmark "MultiplyVector2D" MutateBenchmarks.multiplyVector2D
    results << runBenchmark "MultiplyVector2D" MutateBenchmarks.multiplyVector2D
    results << runBenchmark "MultiplyVector2D" MutateBenchmarks.multiplyVector2D
    results << runBenchmark "MultiplyVector2D" MutateBenchmarks.multiplyVector2D
    results << runBenchmark "MultiplyVector2D" MutateBenchmarks.multiplyVector2D
    
    results << runBenchmark "MultiplyVector3D" MutateBenchmarks.multiplyVector3D
    results << runBenchmark "MultiplyVector3D" MutateBenchmarks.multiplyVector3D
    results << runBenchmark "MultiplyVector3D" MutateBenchmarks.multiplyVector3D
    results << runBenchmark "MultiplyVector3D" MutateBenchmarks.multiplyVector3D
    results << runBenchmark "MultiplyVector3D" MutateBenchmarks.multiplyVector3D
    
    results << runBenchmark "TranslateVector2D" MutateBenchmarks.translateVector2D  
    results << runBenchmark "TranslateVector2D" MutateBenchmarks.translateVector2D  
    results << runBenchmark "TranslateVector2D" MutateBenchmarks.translateVector2D  
    results << runBenchmark "TranslateVector2D" MutateBenchmarks.translateVector2D  
    results << runBenchmark "TranslateVector2D" MutateBenchmarks.translateVector2D
    
    results << runBenchmark "TranslateVector3D" MutateBenchmarks.translateVector3D
    results << runBenchmark "TranslateVector3D" MutateBenchmarks.translateVector3D
    results << runBenchmark "TranslateVector3D" MutateBenchmarks.translateVector3D
    results << runBenchmark "TranslateVector3D" MutateBenchmarks.translateVector3D
    results << runBenchmark "TranslateVector3D" MutateBenchmarks.translateVector3D
    
    results << runBenchmark "SubtractVector2D" MutateBenchmarks.subtractVector2D
    results << runBenchmark "SubtractVector2D" MutateBenchmarks.subtractVector2D
    results << runBenchmark "SubtractVector2D" MutateBenchmarks.subtractVector2D
    results << runBenchmark "SubtractVector2D" MutateBenchmarks.subtractVector2D
    results << runBenchmark "SubtractVector2D" MutateBenchmarks.subtractVector2D
    
    results << runBenchmark "SubtractVector3D" MutateBenchmarks.subtractVector3D
    results << runBenchmark "SubtractVector3D" MutateBenchmarks.subtractVector3D
    results << runBenchmark "SubtractVector3D" MutateBenchmarks.subtractVector3D
    results << runBenchmark "SubtractVector3D" MutateBenchmarks.subtractVector3D
    results << runBenchmark "SubtractVector3D" MutateBenchmarks.subtractVector3D
    
    results << runBenchmark "LengthVector2D" MutateBenchmarks.lengthVector2D
    results << runBenchmark "LengthVector2D" MutateBenchmarks.lengthVector2D
    results << runBenchmark "LengthVector2D" MutateBenchmarks.lengthVector2D
    results << runBenchmark "LengthVector2D" MutateBenchmarks.lengthVector2D
    results << runBenchmark "LengthVector2D" MutateBenchmarks.lengthVector2D
    
    results << runBenchmark "LengthVector3D" MutateBenchmarks.lengthVector3D
    results << runBenchmark "LengthVector3D" MutateBenchmarks.lengthVector3D
    results << runBenchmark "LengthVector3D" MutateBenchmarks.lengthVector3D
    results << runBenchmark "LengthVector3D" MutateBenchmarks.lengthVector3D
    results << runBenchmark "LengthVector3D" MutateBenchmarks.lengthVector3D
    
    results << runBenchmark "DotProductVector2D" MutateBenchmarks.dotProductVector2D  
    results << runBenchmark "DotProductVector2D" MutateBenchmarks.dotProductVector2D  
    results << runBenchmark "DotProductVector2D" MutateBenchmarks.dotProductVector2D  
    results << runBenchmark "DotProductVector2D" MutateBenchmarks.dotProductVector2D  
    results << runBenchmark "DotProductVector2D" MutateBenchmarks.dotProductVector2D
    
    results << runBenchmark "DotProductVector3D" MutateBenchmarks.dotProductVector3D
    results << runBenchmark "DotProductVector3D" MutateBenchmarks.dotProductVector3D
    results << runBenchmark "DotProductVector3D" MutateBenchmarks.dotProductVector3D
    results << runBenchmark "DotProductVector3D" MutateBenchmarks.dotProductVector3D
    results << runBenchmark "DotProductVector3D" MutateBenchmarks.dotProductVector3D
    
    
    Debug.Log ("Test,Mean,Deviation,Count\n" + String.Join("\n", (List.map toString results)))
    System.IO.File.WriteAllText("results.csv", "Test,Mean,Deviation,Count\n" + String.Join("\n", (List.map toString results)))