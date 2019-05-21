using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject SpotLight;
    public AudioSource click;

    private bool light = false;
    // Start is called before the first frame update
    void Start()
    {
        click = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (light == true)
            {
                click.Play();
                turnoff();
            }
            else if (light == false)
            {
                click.Play();
                turnon();
            }
        }
    }


    private void turnoff()
    {
        SpotLight.GetComponent<Light>().range = 0f;
        light = false;
    }

    private void turnon()
    {
        SpotLight.GetComponent<Light>().range = 300f;
        light = true;
    }
}
