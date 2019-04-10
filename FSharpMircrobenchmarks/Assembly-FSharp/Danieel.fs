namespace Assembly_FSharp
open UnityEngine


type Danieeeel() =
    inherit MonoBehaviour()
    
    member this.Update() =
        if Input.GetKeyDown(KeyCode.Space) then 
            Run.start()