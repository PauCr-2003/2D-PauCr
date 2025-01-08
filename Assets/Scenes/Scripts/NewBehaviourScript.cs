using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTransforms : MonoBehaviour
{
    // Define variable
    int variable = 0;
    bool isActive = false;

    // Inicializacion
    void Awake()
    {
        // Executed once
        // We cannot be sure, that other awakes are finished
        // Executed if the object is inactive
        variable = 25;
        Debug.Log("Awake " + name); // To print message in console
    }

    void Start()
    {
        // Executed once
        // This is executed after awake has been called.
        // Executed if the component is active
        Debug.Log("Start " + name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateTransform()
    {

    }
}