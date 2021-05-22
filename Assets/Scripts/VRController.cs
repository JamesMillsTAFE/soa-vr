using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// These make it so that the script cannot function without them
// so they will be added when this script is added, and not be able
// to be removed until this script is removed.
[RequireComponent(typeof(VRInput))]
[RequireComponent(typeof(VRPose))]
public class VRController : MonoBehaviour
{
    public InputActionReference velocityAction;
    public InputActionReference angularVelocityAction;

    public Vector3 velocity;
    public Vector3 angularVelocity;

    public VRInput input;
    public VRPose pose;

    private bool isSetup = false;

    public void Setup()
    {
        isSetup = true;

        // These already live on the same gameObject so we can retrieve them
        // without setting in the editor
        input = gameObject.GetComponent<VRInput>();
        pose = gameObject.GetComponent<VRPose>();

        // Setup the input and pose components
        input.Setup();
        pose.Setup();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isSetup)
        {
            // Copy the device velocity into the velocity variables
            velocity = velocityAction.action.ReadValue<Vector3>();
            angularVelocity = angularVelocityAction.action.ReadValue<Vector3>();
        }
    }
}
