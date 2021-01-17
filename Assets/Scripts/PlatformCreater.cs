using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreater : MonoBehaviour
{
    [SerializeField]
    private GameObject PlatformPrefab;
    [SerializeField]
    private GameObject StickPrefab;

    [SerializeField]
    private float SpawnDistance = 27.2f;

    private float platdist = 4f;

    public Transform Tower,playerTr;

    private float LastPlayerY;
    private Vector3 PlatformPosition, StickPosition;
    private Quaternion PlatformRotation, StickRotation;
    private Vector3 PlayerPosition;

    private void Start()
    {
        LastPlayerY = 0;
        //First Platforms Init
        PlatformRotation.eulerAngles = new Vector3(0, -90f, 0);
        PlatformPosition = new Vector3(0, 3, 0);
        StickPosition = PlatformPosition;
        StickRotation = PlatformRotation;
        GameObject.Instantiate(PlatformPrefab, PlatformPosition, PlatformRotation);

        while (PlatformPosition.y <= SpawnDistance)
        {
            
            PlatformPosition += new Vector3(0, platdist * Random.Range(1, 3), 0);
            StickPosition = PlatformPosition;

            int x = Random.Range(0, 2);
            if (x == 1)
            {
                PlatformRotation.eulerAngles += new Vector3(0, 22.5f * Random.Range(0, 3), 0);
                StickRotation.eulerAngles = PlatformRotation.eulerAngles;
            }

            else if (x == 0)
            {
                PlatformRotation.eulerAngles -= new Vector3(0, 22.5f * Random.Range(0, 3), 0);
                StickRotation.eulerAngles = PlatformRotation.eulerAngles;
            }

            x = Random.Range(0, 2);
            if (x == 1)
                GameObject.Instantiate(PlatformPrefab, PlatformPosition, PlatformRotation);
            else
                GameObject.Instantiate(StickPrefab, StickPosition, StickRotation);

        }

    }

    private void Update()
    {
        //y ekseni ikinin katları
        //rotation 22,5 oynayacak yde
        PlayerPosition = playerTr.position;

        if ((PlayerPosition.y - LastPlayerY >= platdist) && (PlatformPosition.y- PlayerPosition.y <= SpawnDistance))
        {
            

            PlatformPosition += new Vector3(0, platdist * Random.Range(1, 3), 0);
            StickPosition = PlatformPosition;
            LastPlayerY = PlayerPosition.y;

            int x = Random.Range(0, 100);
            if (x >= 25)
            {
                PlatformRotation.eulerAngles += new Vector3(0, 22.5f * Random.Range(0, 3), 0);
                StickRotation.eulerAngles = PlatformRotation.eulerAngles;
            }

            else
            {
                PlatformRotation.eulerAngles -= new Vector3(0, 22.5f * Random.Range(0, 3), 0);
                StickRotation.eulerAngles = PlatformRotation.eulerAngles;
            }
            x = Random.Range(0,2);
            if(x == 1)
            GameObject.Instantiate(PlatformPrefab, PlatformPosition, PlatformRotation);
            else
            GameObject.Instantiate(StickPrefab, StickPosition, StickRotation);
        }

        //if ((LastPlayerY - 2 * SpawnDistance) > 0)
        //    Destroy



     }

}
