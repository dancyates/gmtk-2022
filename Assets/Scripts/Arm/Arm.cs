using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    // private void OnCollisionEnter(Collision other)
    // {
    //     // Note: this doesn't quite work when a prop is pushed by another prop,
    //     //       but works when the arm hits props directly.
    //     var prop = other.gameObject.GetComponent<Prop>();
    //     if (prop)
    //     {
    //         prop.points = 0;
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        // Note: this doesn't quite work when a prop is pushed by another prop,
        //       but works when the arm hits props directly.
        var prop = other.gameObject.GetComponent<Prop>();
        if (prop)
        {
            prop.points = 0;
        }
    }
}
