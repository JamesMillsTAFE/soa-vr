using System;

using UnityEngine;
using UnityEngine.Events;

public class InteractionEvent : UnityEvent<InteractionArgs> {}

[Serializable]
public class InteractionArgs
{
    public VRController controller;
    public Rigidbody rigidbody;
    public Collider collider;

    public InteractionArgs(VRController _controller, Rigidbody _rigidbody, Collider _collider)
    {
        controller = _controller;
        rigidbody = _rigidbody;
        collider = _collider;
    }
}
