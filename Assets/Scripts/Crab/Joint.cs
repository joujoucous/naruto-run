using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public Joint m_child;

    public Joint GetChild()
    {
        return m_child;
    }

    public void Rotate(float angle_d)
    {
        transform.Rotate(UnityEngine.Vector3.up * angle_d);
        transform.Rotate(UnityEngine.Vector3.right * angle_d);
    }
}
