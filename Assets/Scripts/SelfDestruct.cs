using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelfDestruct : MonoBehaviour
{
    public AudioSource collusionSound;
    private GameObject Sound;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Sound = GameObject.FindGameObjectWithTag("CollusionSound");
        collusionSound = Sound.GetComponent<AudioSource>();
        Destroy(gameObject, 35f);
    }
    private void OnCollisionEnter(Collision collision)
    {

        collusionSound.Play();
        
        StartCoroutine(selfDestructTime(Random.Range(1f,3f),gameObject));       
        
    }

    IEnumerator selfDestructTime(float t, GameObject obj)
    {
        yield return new WaitForSeconds(t);
        if (player.GetComponent<Grappling>().prev == obj)
        {
            player.GetComponent<Grappling>().StopGrapple();
        }
        Destroy(obj);

    }

    private bool IsDestroyed(GameObject gameObject)
    {
        return gameObject == null && !ReferenceEquals(gameObject, null);
    }

}
