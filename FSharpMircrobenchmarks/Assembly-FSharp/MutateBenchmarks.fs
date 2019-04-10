module MutateBenchmarks 
open UnityEngine

let scaleVector2D scalar =
    let mutable v1 = new Vector2(1.0f, 1.0f)
    v1 <- v1 * float32 scalar
    v1.magnitude

let scaleVector3D scalar =
    let mutable v1 = new Vector3(1.0f, 1.0f, 1.0f)
    v1 <- v1 * float32 scalar
    v1.magnitude

let multiplyVector2D i =
    let mutable v1 = new Vector2(1.0f, 1.0f)
    let mutable v2 = new Vector2(float32 i, float32 i)
    v1.Scale(v2)
    v1.magnitude
    
let multiplyVector3D i =
    let mutable v1 = new Vector3(1.0f, 1.0f, 1.0f)
    let mutable v2 = new Vector3(float32 i, float32 i, float32 i)
    v1.Scale(v2)
    v1.magnitude
    
let translateVector2D i =
    let mutable v1 = new Vector2(1.0f, 1.0f);
    let mutable v2 = new Vector2(float32 i, float32 i);
    let v3 = v1 + v2
    v1.magnitude
    
let translateVector3D i =
    let mutable v1 = new Vector3(1.0f, 1.0f, 1.0f);
    let mutable v2 = new Vector3(float32 i, float32 i, float32 i);
    let v3 = v1 + v2
    v1.magnitude
    
let subtractVector2D i =
    let mutable v1 = new Vector2(float32 i, float32 i)
    let v2 = new Vector2(1.0f, 1.0f)
    v1 <- v1 - v2
    v1.magnitude
    
let subtractVector3D i =
    let mutable v1 = new Vector3(float32 i, float32 i, float32 i)
    let v2 = new Vector3(1.0f, 1.0f, 1.0f)
    v1 <- v1 - v2
    v1.magnitude
    
let lengthVector2D i =
    let v1 = new Vector2(float32 i, float32 i)
    v1.magnitude
    
let lengthVector3D i =
    let v1 = new Vector3(float32 i, float32 i, float32 i)
    v1.magnitude
    
let dotProductVector2D i =
    let v1 = new Vector2(1.0f, 1.0f)
    let v2 = new Vector2(float32 i, float32 i)
    Vector2.Dot(v1, v2)
    
let dotProductVector3D i =
    let v1 = new Vector3(1.0f, 1.0f, 1.0f)
    let v2 = new Vector3(float32 i, float32 i, float32 i)
    Vector3.Dot(v1, v2)