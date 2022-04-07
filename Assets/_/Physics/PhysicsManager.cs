using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    // https://docs.unity3d.com/2021.2/Documentation/Manual/PhysicsSection.html

    // Gravity
    public Vector3 Gravity { get { return new Vector3(); } set { } }

    public void ResetGravity() {
        Gravity = new Vector3(0, -9.80665f, 0);
    }
}
