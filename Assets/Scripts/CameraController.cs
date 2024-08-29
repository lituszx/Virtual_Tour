using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CameraController : MonoBehaviour
{
    public float speed;
    public int direccion;
    public EventSystem eSystem;
    // Start is called before the first frame update
    void Start()
    {
        direccion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * direccion * Time.deltaTime);
    }
    public void RotateForward()
    {
        direccion = 1;
    }
    public void RotateBackward()
    {
        direccion = -1;
    }
    public void StopRotation()
    {
        direccion = 0;
        eSystem.SetSelectedGameObject(null);
    }
    public void AutoPlay()
    {
        if(direccion == 0)
        {
            direccion = 1;
        }
        else
        {
            direccion = 0;
        }
        eSystem.SetSelectedGameObject(null);
    }
    public void ZoomIn()
    {
        Camera.main.fieldOfView = 30;
    }
    public void ZoomOut()
    {
        Camera.main.fieldOfView = 90;
    }
    public void ZoomNormal()
    {
        Camera.main.fieldOfView = 60;
    }
}
