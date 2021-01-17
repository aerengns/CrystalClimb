
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;

    public GameObject GameManager;

    public GameObject deathSc;

    public float JumpSpeed = 3f;
    public float MovSpeed = 0f;

    public AudioSource jumpSound;
    public AudioSource deathSound;

    private bool grounded;
    private bool dead;
    void Start()
    {
        Time.timeScale = 1;
        grounded = true;
        dead = false;
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        
        InputManager();

        if (transform.position.y <= 0f && GameManager.GetComponent<PlayerDisable>().score >= 20 && !dead)
        {
            Die();
            dead = true;
        }
            

    }
    
    void InputManager()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            PauseGame();
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (Input.GetKeyDown(KeyCode.R))
            Restart();

        if(Input.GetKey(KeyCode.A))
        {
            moveAD(-1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveAD(1);
        }
        
        /*if (Input.GetKey(KeyCode.W))
        {
            moveWS(1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveWS(-1);
        }*/
    }

    void Die()
    {
        Time.timeScale = 0;
        deathSound.Play();
        deathSc.SetActive(true);

    }

    void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void PauseGame()
    {
        GameManager.GetComponent<Manager>().showPauseMenu();
        Time.timeScale = 0;
    }

    void moveAD(int dir)
    {
        Vector3 temp = new Vector3(0f, transform.position.y, 0f);
        Vector3 ADdogrultu = Vector3.Cross((transform.position - temp) ,CameraFollow.WorldUp).normalized;
        //transform.position += dir * ADdogrultu * MovSpeed * Time.deltaTime;
        rb.velocity += dir * ADdogrultu * MovSpeed * Time.deltaTime;

    }

    public void putUsInBoundry()
    {
        Vector2 pos = new Vector2(transform.position.x,transform.position.z).normalized;
        pos *= 10.3f;
        transform.position = new Vector3(pos.x, transform.position.y, pos.y);
    }


    /*
    void moveWS(int dir)
    {

        int inBound = inBoundaries();
        if(inBound == 0)
        {
            Vector3 WSdogrultu = (transform.position - CameraFollow.origin).normalized;
            transform.position -= dir * WSdogrultu * MovSpeed * Time.deltaTime;
        }
        else if(inBound == 1 && dir == -1)
        {
            Vector3 WSdogrultu = (transform.position - CameraFollow.origin).normalized;
            transform.position -= dir * WSdogrultu * MovSpeed * Time.deltaTime;
        }
        else if (inBound == 2 && dir == 1)
        {
            Vector3 WSdogrultu = (transform.position - CameraFollow.origin).normalized;
            transform.position -= dir * WSdogrultu * MovSpeed * Time.deltaTime;
        }


    }
    
    int inBoundaries()
    {
        float x = transform.position.x, z = transform.position.z;
        if( (x * x + z * z) > 94.1f && (x * x + z * z) < 256f)
                return 0;
        else if((x * x + z * z) <= 94.1f)
            return 1;
        else if ( (x * x + z * z) > 256f)
            return 2;
        return -1;

    }*/

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    void Jump()
    {
        if(grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpSpeed, rb.velocity.z);
            grounded = false;
            jumpSound.Play();

        }
        
    }

}
