﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMazeTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }
   
}
