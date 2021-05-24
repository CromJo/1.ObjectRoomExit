using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] GameObject m_FlashLight;
    [SerializeField] GameObject m_FlashLightGround;
    Light m_Light;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PickUpFlashLight()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
