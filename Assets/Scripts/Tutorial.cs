using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject panel;
    public GameObject panel2;
    public GameObject player;
    int sit;
    private void Start()
    {
        sit = 0;
    }

    private void Update()
    {
        if(player.transform.position.y >= 20f)
        {
            panel.SetActive(false);
            panel2.SetActive(true);
        }
    }

    public void MyStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void Buton()
    {
        if(sit == 0)
        {
            text.text = "Press space to jump and climb the platforms";
        }
        if(sit == 1)
        {
            text.text = "Hold left mouse button to grapple";
        }
        if(sit == 2)
        {
            text.text= "Beware! Platforms are temporary. Be quick, they may randomly disappear";
        }
        if(sit == 3)
        {
            text.text = "Climb to the highest you can reach";
        }
        if(sit == 4)
        {
            panel.SetActive(false);
        }
        sit++;
    }
}
