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
        Debug.Log("Hi from C#");
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Shoud've been running benchmarks");
            var x = _fsLib.benchmarkRunner();
        }
    }
}
