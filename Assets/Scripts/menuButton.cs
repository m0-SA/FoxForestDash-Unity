using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuButton : MonoBehaviour
{
    [SerializeField]
    int level,
        playerHealth;
    [SerializeField]
    bool doubleJump,
        canRollDash,
        dashUnlocked,
        doubleJumpUnlocked;


    // Start is called before the first frame update
    public void loadStart()
    {
        health.Instance.playerHealth = playerHealth;
        health.Instance.maxHealth = playerHealth;

        PlayerController.Instance.doubleJump = doubleJump;
        PlayerController.Instance.canRollDash = canRollDash;
        PlayerController.Instance.dashUnlocked = dashUnlocked;

        if (dashUnlocked)
        {
            TextMeshProUGUI dashText = GameObject.FindWithTag("DashText").GetComponent<TextMeshProUGUI>();
            dashText.text = "Dash Available";
            dashText.color = Color.green;
        }


        PlayerController.Instance.doubleJumpUnlocked = doubleJumpUnlocked;

        GameObject.FindWithTag("Player").transform.position = Vector3.zero;

        SceneManager.LoadScene(level);
    }
}
