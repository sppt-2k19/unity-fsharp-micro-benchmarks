namespace Assembly_FSharp
open UnityEngine


type Danieeeel() =
    inherit MonoBehaviour()
    
    member this.Update() =
        if Input.GetKeyDown(KeyCode.Space) then 
            UnityEngine.Debug.Log "starting"
            Run.start()
            UnityEngine.Debug.Log "finished"