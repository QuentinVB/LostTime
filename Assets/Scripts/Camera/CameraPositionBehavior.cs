using UnityEngine;
using System.Collections;

public class CameraPositionBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow)) //Input for rotation towards left
        {
            transform.RotateAround(Vector3.zero, Vector3.up, 30 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow)) //Input for rotation towards right
        {
            transform.RotateAround(Vector3.zero, Vector3.down, 30 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow)) //Input for rotation above player
        {
            transform.RotateAround(Vector3.zero, Vector3.left, 30 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow)) //Input for rotation below player
        {
            transform.RotateAround(Vector3.zero, Vector3.right, 30 * Time.deltaTime);
        }
    }
}
//Vector3.down = rotation de la camera vers la droite
//Vector3.up = rotation vers la gauche.
//transform.RotateAround(Vector3.zero, Vector3.down, 30 * Time.deltaTime);
