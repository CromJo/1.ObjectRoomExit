using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public void Equip(Transform equipSoket)
    {
        GetComponent<MeshCollider>().enabled = false;

        transform.SetParent(equipSoket, false);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }
}
