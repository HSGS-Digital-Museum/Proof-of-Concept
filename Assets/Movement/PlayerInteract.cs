using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance=5f;
    [SerializeField]
    private LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        cam=GetComponent<FPSController>().m_fpsCamera;
    }
    
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);  
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>()!=null)
            {
                if(Input.GetKey(KeyCode.E))
                {
                    Debug.Log(hitInfo.collider.GetComponent<Interactable>().message);
                    // Paste interaction code here or link with other c# object script
                }
            }
        }
    }
}
