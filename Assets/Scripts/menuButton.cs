using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
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

    public Animator transition;

    // Start is called before the first frame update
    public void loadStart()
    {
        health.Instance.playerHealth = playerHealth;
        health.Instance.maxHealth = playerHealth;

        PlayerController.Instance.doubleJump = doubleJump;
        PlayerController.Instance.canRollDash = canRollDash;
        PlayerController.Instance.dashUnlocked = dashUnlocked;
        PlayerController.Instance.doubleJumpUnlocked = doubleJumpUnlocked;

        if (dashUnlocked)
        {
            TextMeshProUGUI dashText = GameObject.FindWithTag("DashText").GetComponent<TextMeshProUGUI>();
            dashText.text = "Dash Available";
            dashText.color = Color.green;
        }

        GameObject backButton = GameObject.FindWithTag("Back");
        backButton.GetComponent<UnityEngine.UI.Button>().enabled = true;
        backButton.GetComponent<UnityEngine.UI.Image>().enabled = true;
        backButton.GetComponentInChildren<TextMeshProUGUI>().enabled = true;

        

        StartCoroutine(loadScene(level));
        
    }

    IEnumerator loadScene(int level)
    {
        transition.SetTrigger("loadOut");
        yield return new WaitForSeconds(1);
        GameObject.FindWithTag("Player").transform.position = Vector3.zero;
        SceneManager.LoadScene(level);
        transition.SetTrigger("loadIn");
        Debug.Log("this palys");
    }

}
