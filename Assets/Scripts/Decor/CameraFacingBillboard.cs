using UnityEngine;
using System.Collections;

public class CameraFacingBillboard : MonoBehaviour
{
    void Start ()
    {
    }
    //bind this to an halo
    void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
            Camera.main.transform.rotation * Vector3.up);
    }
}