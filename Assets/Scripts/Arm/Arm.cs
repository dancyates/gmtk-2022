using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var prop = other.gameObject.GetComponent<Prop>();
        if (prop)
        {
            prop.points = 0;
        }
    }
}
