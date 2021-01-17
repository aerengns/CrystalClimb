using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Grappling : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 GrapplePoint;
    public LayerMask IsGrappable;
    public Transform tip;
    private ConfigurableJoint joint;
    public float maxDistance = 20f;


    public Slider mySlider;
    public bool easy = true;

    public AudioSource ropeSound;
    public GameObject cam;

    private bool grapled;
    public GameObject prev;



    private void Awake()
    {

        lr = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        easy = true;
        if (PlayerPrefs.GetInt("arda") == 0)
        {
            PlayerPrefs.SetInt("arda", 1);
            PlayerPrefs.SetInt("easy", 1);
        }
       if(SceneManager.GetActiveScene().name != "Tutorial")
            easy = PlayerPrefs.GetInt("easy") == 1 ? true : false;

        mySlider.value = gameObject.GetComponent<Grappling>().easy ? 0f : 1f;
        

    }



    private void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();

        }
            
        else if (Input.GetMouseButtonUp(0))
            StopGrapple();
    }

    private void LateUpdate()
    {
        
        DrawRope();
        
        GetComponent<PlayerScript>().putUsInBoundry();
        cam.GetComponent<CameraFollow>().cameraFollow();
    }

    void StartGrapple()
    {
        
        if (!gameObject.GetComponent<PlayerScript>().GameManager.GetComponent<Manager>().pauseMenu.activeSelf)
        {
            
            RaycastHit hit;
            
            //if(Physics.Raycast(tip.position, tip.up, out hit, maxDistance, IsGrappable))
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, maxDistance, IsGrappable))
            {
                grapled = true;
                ropeSound.Play();
                GrapplePoint = hit.point;
                GameObject destroyee = hit.collider.gameObject;



                prev = destroyee;
                if (!easy)
                {
                    
                    StartCoroutine(Disabler(Random.Range(2f, 3f), destroyee));
                }


                joint = gameObject.AddComponent<ConfigurableJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = GrapplePoint;

                float distance = Vector3.Distance(transform.position, GrapplePoint);

                //xyz limit
                joint.xMotion = ConfigurableJointMotion.Limited;
                joint.yMotion = ConfigurableJointMotion.Limited;
                joint.zMotion = ConfigurableJointMotion.Limited;


                //Distance limit
                SoftJointLimit limit = joint.linearLimit;
                limit.limit = distance;
                limit.bounciness = 0;
                joint.linearLimit = limit;

                //Spring limit
                    //SoftJointLimitSpring spring = joint.linearLimitSpring;
                //spring.spring = 40f;
                //joint.linearLimitSpring = spring;

                lr.positionCount = 2;
                    
                
                
                
                
            }
            
        }

        
    }

    IEnumerator Disabler(float t, GameObject obj)
    {
        yield return new WaitForSeconds(t);
        Destroy(obj);
        if (obj == prev)
        {
            StopGrapple();
        }

    }


    void DrawRope()
    {
        if (!grapled) return;
        lr.SetPosition(0, tip.position);
        lr.SetPosition(1, GrapplePoint);
    }

    public void StopGrapple()
    {
        if(grapled)
        {
            lr.positionCount = 0;
            Destroy(joint);
            grapled = false;
        }

    }

}
