using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float obrot = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * obrot * Time.deltaTime);
    }
}

