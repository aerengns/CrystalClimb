using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisable : MonoBehaviour
{
    public GameObject player;
    bool done;
    float time;
    public GameObject cam;
    public ParticleSystem particle;

    public AudioSource TowerFall;

    public int score = 0;
    void Start()
    {
        particle.Stop();
        done = false;
        time = 0f;
        player.GetComponent<PlayerScript>().enabled = false;
        player.GetComponent<Grappling>().enabled = false;
        GetComponent<PlatformCreater>().enabled = false;
    }

    
    void Update()
    {
        if(!done)
        {
            cam.GetComponent<CameraFollow>().cameraFollow();
            time += Time.deltaTime;

            if(time >= 2.0f)
            {
                done = true;
                player.GetComponent<PlayerScript>().enabled = true;
                player.GetComponent<Grappling>().enabled = true;
                GetComponent<PlatformCreater>().enabled = true;
                particle.Play();
                TowerFall.Play();
            }
        }
        else
        {
            if( (int) player.transform.position.y > score)
            {
                score = (int)player.transform.position.y;
                GetComponent<Manager>().updateScore(score);
            }
        }
    }
}
