using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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

        PlayerController.Instance.doubleJump = doubleJump;
        PlayerController.Instance.canRollDash = canRollDash;
        PlayerController.Instance.dashUnlocked = dashUnlocked;
        PlayerController.Instance.doubleJumpUnlocked = doubleJumpUnlocked;


        StartCoroutine(loadScene(level));
        
    }

    public void setHealth()
    {
        health.Instance.playerHealth = playerHealth;
        health.Instance.maxHealth = playerHealth;
    }

    IEnumerator loadScene(int level)
    {
        transition.SetTrigger("loadOut");
        yield return new WaitForSeconds(1);
        setHealth();

        GameObject.FindWithTag("Player").transform.position = Vector3.zero;

        GameObject[] menuButtons = GameObject.FindGameObjectsWithTag("MenuButton");
        foreach (GameObject button in menuButtons)
        {
            button.GetComponent<Button>().enabled = false;
            button.GetComponent<Image>().enabled = false;
            button.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        }

        GameObject health = GameObject.FindWithTag("HealthBar");
        health.GetComponentInChildren<TextMeshProUGUI>().enabled = true;

        if (dashUnlocked)
        {
            TextMeshProUGUI dashText = GameObject.FindWithTag("DashText").GetComponent<TextMeshProUGUI>();
            dashText.text = "Dash Available";
            dashText.color = Color.green;
        }

        GameObject backButton = GameObject.FindWithTag("Back");
        backButton.GetComponent<Button>().enabled = true;
        backButton.GetComponent<Image>().enabled = true;
        backButton.GetComponentInChildren<TextMeshProUGUI>().enabled = true;

        SceneManager.LoadScene(level);
        transition.SetTrigger("loadIn");
    }

}
