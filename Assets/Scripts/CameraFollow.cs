using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public  GameObject player;
    public Vector3 difference;
    private  Vector3 coord;
    public static Vector3 origin;
    public static Vector3 WorldUp;

    public GameObject tip;
    void Start()
    {
        origin = new Vector3(0f, 0f, 0f);
        WorldUp = new Vector3(0f, 1f, 0f);
    }

    public void cameraFollow()
    {
        coord = (player.transform.position - origin);
        coord = coord * 1.55f;
        // coord.Set(coord.x, player.transform.position.y > 4 ? player.transform.position.y - 2f : player.transform.position.y + 2f, coord.z);
        coord.Set(coord.x, player.transform.position.y + 1f, coord.z);
        transform.position = coord;
        transform.LookAt(tip.transform  , WorldUp);

    }

}
