using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuButton : MonoBehaviour
{
    public GameObject player;
    public GameObject UI;

    // Start is called before the first frame update
    public void loadStart()
    {
        Destroy(player);
        SceneManager.LoadScene(1);
    }
}
