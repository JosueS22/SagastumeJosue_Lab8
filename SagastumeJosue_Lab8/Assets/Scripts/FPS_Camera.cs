using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS_Camera : MonoBehaviour
{

    public Camera FPSCamera;

    public float horizontalSpeed;
    public float verticalSpeed;
    public GameObject light;
    public float startLight;

    public Text text;

    float h;
    float v;
    
    void Start()
    {
        startLight = light.GetComponent<Light>().intensity;
        text.enabled = false;
    }

    
    void Update()
    {
        Walk();
        text.enabled = false;
        RaycastHit hit;
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, 15f))
        {
            if (hit.collider.gameObject.CompareTag("Box") == true)
            {
                text.text = "Caja";
                text.enabled = true;
            } else if (hit.collider.gameObject.CompareTag("Chair") == true)
            {
                text.text = "Silla";
                text.enabled = true;
            }
            else if (hit.collider.gameObject.CompareTag("Table") == true)
            {
                text.text = "Mesa";
                text.enabled = true;
            }
            else if (hit.collider.gameObject.CompareTag("T.V.") == true)
            {
                text.text = "Televisor";
                text.enabled = true;
            }
            else if (hit.collider.gameObject.CompareTag("") == true)
            {
                text.text = " ";
                text.enabled = true;
            }
            else
                text.enabled = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Room")
        {
            light.GetComponent<Light>().intensity = startLight + (2*Mathf.Cos(5*Time.time));
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Room")
        {
            light.GetComponent<Light>().intensity = 0f;
        }
    }

    void Walk()
    {
        h = horizontalSpeed * Input.GetAxis("Mouse X");
        v = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(0, h, 0);
        FPSCamera.transform.Rotate(-v, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 0.5f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -0.5f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.5f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.5f, 0, 0);
        }
    }
    
}
