using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class InteractableObject : MonoBehaviour
{
    public bool canGrab = true;

    public Rigidbody rigidbody;
    public SphereCollider collider;
    
    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        collider = gameObject.GetComponent<SphereCollider>();
    }
}
