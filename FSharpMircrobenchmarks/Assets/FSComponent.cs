using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fsharp_benchmarks;


public class FSComponent : MonoBehaviour
{
    private FSLib _fsLib;
    void Start()
    {
        _fsLib = new FSLib();
        _fsLib.FStart();
        Debug.Log(Bench.lengthVector2D(2));
        Debug.Log("Hi from C#");
        
    }

    private void Update()
    {
        _fsLib.benchmarkRunner();
    }
}
