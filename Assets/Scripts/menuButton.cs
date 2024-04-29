using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuButton : MonoBehaviour
{
    [SerializeField]
    int level,
        health;
    [SerializeField]
    bool doubleJump,
        canRollDash,
        dashUnlocked,
        doubleJumpUnlocked;


    // Start is called before the first frame update
    public void loadStart()
    {
        SceneManager.LoadScene(level);
    }
}
