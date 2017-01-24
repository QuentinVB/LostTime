using UnityEngine;
using System.Collections;

public class CameraPositionBehavior : MonoBehaviour
{
    public VirtualRightJoystick rightJoystick;
    private float horizontalInput;
    private Transform initialPos;
    private Vector3 astridPos;

    // Use this for initialization
    void Start()
    {
       // initialPos.localPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = rightJoystick.RightHorizontal();
        astridPos = GameObject.Find("AstridPlayer").transform.position;
        if (horizontalInput > 0.5)
        {
            transform.RotateAround(astridPos, Vector3.up, 30 * Time.deltaTime);
        }
        if (horizontalInput < -0.5)
        {
            transform.RotateAround(astridPos, Vector3.down, 30 * Time.deltaTime);
        }
    }
}
//Vector3.down = rotation de la camera vers la droite
//Vector3.up = rotation vers la gauche.
//transform.RotateAround(Vector3.zero, Vector3.down, 30 * Time.deltaTime);
