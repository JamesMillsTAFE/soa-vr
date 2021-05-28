using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class VRInput : MonoBehaviour
{
    [System.Serializable]
    public class TeleportEvent : UnityEvent<Vector3> {}
    
    public InputActionReference grab;
    public InputActionReference teleport;

    public UnityEvent onGrabPressed = new UnityEvent();
    public UnityEvent onGrabReleased = new UnityEvent();

    public TeleportEvent onTeleported = new TeleportEvent();

    private bool isSetup = false;

    public void Setup()
    {
        // We are now ready to run
        isSetup = true;

        // Setup the input detection here
        grab.action.performed += OnGrabPerformed;
        grab.action.canceled += OnGrabCanceled;
        teleport.action.performed += OnTeleportPerformed;
    }

    private void OnGrabPerformed(InputAction.CallbackContext _context)
    {
        onGrabPressed.Invoke();
    }

    private void OnGrabCanceled(InputAction.CallbackContext _context)
    {
        onGrabReleased.Invoke();
    }

    private void OnTeleportPerformed(InputAction.CallbackContext _context)
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            onTeleported.Invoke(hit.point);
        }
    }
}
