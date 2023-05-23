using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public Camera camera;
    
    void Start(){camera.transform.position = new Vector3(0, 0, 0);}

    public void tpCamera(float newPos) {camera.transform.position = new Vector3(newPos, 0, 0);}

    
}
