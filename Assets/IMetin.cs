using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMetin : MonoBehaviour
{
    public float radius = 3f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(radius, radius, radius));
    }
}
