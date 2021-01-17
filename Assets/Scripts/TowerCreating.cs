using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreating : MonoBehaviour
{
    [SerializeField]
    private GameObject TowerPrefab;

    [SerializeField]
    private float RespawnHeight = 26.5f;

    public Transform player;

    private float TowerHeight=13f;
    private Vector3 PlayerPosition;
    private Quaternion rot= new Quaternion();

    private void Start()
    {
        rot.eulerAngles = new Vector3(0, 0, 0);
    }
    void Update()
    {
        PlayerPosition = player.position;
        if(PlayerPosition.y >= TowerHeight)
        {
            GameObject.Instantiate(TowerPrefab, new Vector3(0, TowerHeight+RespawnHeight, 0), rot);
            TowerHeight += RespawnHeight;
        }
    }

}
