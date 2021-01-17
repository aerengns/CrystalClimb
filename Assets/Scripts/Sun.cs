using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public GameObject camera1;


    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(33f, camera1.transform.rotation.eulerAngles.y, 0f);
    }
}
