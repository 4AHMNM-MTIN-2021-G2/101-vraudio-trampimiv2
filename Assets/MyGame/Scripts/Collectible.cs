using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("col: " + collision.gameObject.name);
    }

}
