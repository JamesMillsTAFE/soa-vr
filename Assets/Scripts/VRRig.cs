using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRig : MonoBehaviour
{
    public VRController left;
    public VRController right;
    public VRPose HMD;
    public Transform PlayArea;

    // Start is called before the first frame update
    void Awake()
    {
        // We tell the HMD to run and setup.
        HMD.Setup();

        // Setup the controllers
        left.Setup();
        right.Setup();
    }
}
