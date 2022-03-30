using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    private int currentContact;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D()
    {
        currentContact++;
    }

    void OnTriggerExit2D()
    {
        currentContact--;
    }

    public bool state()
    {
        return currentContact > 0;
    }
}
