using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // This is how we get access to the new Unity input code

public class VRPose : MonoBehaviour
{
    // This will hold the information about the position and rotation
    // linked with the InputActions.
    private class PoseTransform
    {
        // An identity Quaternion is just a zero rotation
        public Quaternion rotation = Quaternion.identity;
        public Vector3 position = Vector3.zero;
    }

    // This is a variable type that corresponds to an Action within the InputSystem
    public InputActionReference positionAction;
    public InputActionReference rotationAction;

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    private void FixedUpdate()
    {
        // Apply the calculated pose to this object in the scene
        PoseTransform pose = GetPose();
        transform.position = pose.position;
        transform.rotation = pose.rotation;
    }

    // This gets the rotation and position data from the InputActions
    // and wraps them into a class for easy usage
    private PoseTransform GetPose()
    {
        // This is how you make a 'new' instance of the class. So this is
        // and object made from the 'blueprint'.
        PoseTransform pose = new PoseTransform();

        // Here we are accessing the value that the action is containing.
        pose.position = positionAction.action.ReadValue<Vector3>(); // Get the object position
        pose.rotation = rotationAction.action.ReadValue<Quaternion>(); // Get the object rotation

        // Send the pose data back out of the function to be used elsewhere.
        return pose;
    }
}
