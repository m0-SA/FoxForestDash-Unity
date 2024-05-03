using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class displayOffMenu : MonoBehaviour
{

    void Awake()
    {
        GameObject backButton = GameObject.FindWithTag("Back");
        backButton.GetComponent<UnityEngine.UI.Button>().enabled = false;
        backButton.GetComponent<Image>().enabled = false;
        backButton.GetComponentInChildren<TextMeshProUGUI>().enabled = false;

        GameObject health = GameObject.FindWithTag("HealthBar");
        health.GetComponentInChildren<TextMeshProUGUI>().enabled = false;

        TextMeshProUGUI dashText = GameObject.FindWithTag("DashText").GetComponent<TextMeshProUGUI>();
        dashText.text = "";

    }

    // Start is called before the first frame update
    void Start()
    {
        health.Instance.playerHealth = -1;
        health.Instance.maxHealth = -1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
