using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(VRController))]
public class GrabInteraction : MonoBehaviour
{
	public InteractionEvent grabbed = new InteractionEvent();
	public InteractionEvent released = new InteractionEvent();
	
	private InteractableObject collidingObject;
	private InteractableObject heldObject;
	
	// The held object's original parent before it got reparented to this controller
	private Transform heldOriginalParent;

	private VRController controller;

	// Start is called before the first frame update
	void Start()
	{
		controller = gameObject.GetComponent<VRController>();
		controller.input.onGrabPressed.AddListener(OnGrabPressed);
		controller.input.onGrabReleased.AddListener(OnGrabReleased);
	}

	private void OnGrabReleased()
	{
		if(heldObject != null)
			ReleaseObject();
	}

	private void OnGrabPressed()
	{
		if(collidingObject != null)
			GrabObject();
	}

	private void SetCollidingObject(Collider _other)
	{
		InteractableObject interactable = _other.GetComponent<InteractableObject>();
		if(collidingObject != null || interactable == null)
			return;
		collidingObject = interactable;
	}

	private void OnTriggerEnter(Collider _other) => SetCollidingObject(_other);

	private void OnTriggerExit(Collider _other)
	{
		if(collidingObject == _other.GetComponent<InteractableObject>())
			collidingObject = null;
	}

	private void GrabObject()
	{
		heldObject = collidingObject;
		collidingObject = null;

		heldOriginalParent = heldObject.transform.parent;
		heldObject.transform.parent = transform;
		heldObject.transform.localPosition = Vector3.zero;
		heldObject.transform.localRotation = Quaternion.identity;

		heldObject.rigidbody.isKinematic = true;

		grabbed.Invoke(new InteractionArgs(controller, heldObject.rigidbody, heldObject.collider));
	}

	private void ReleaseObject()
	{
		heldObject.rigidbody.isKinematic = false;
		heldObject.transform.SetParent(heldOriginalParent);

		heldObject.rigidbody.velocity = controller.velocity;
		heldObject.rigidbody.angularVelocity = controller.angularVelocity;

		released.Invoke(new InteractionArgs(controller, heldObject.rigidbody, heldObject.collider));
		heldObject = null;
	}
}