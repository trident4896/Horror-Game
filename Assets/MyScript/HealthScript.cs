using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField]
    Text HealthText;
    [SerializeField]
    GameObject DeathPanel;
    // Start is called before the first frame update
    void Start()
    {
        DeathPanel.gameObject.SetActive(false);

        HealthText.text = SaveScript.PlayerHealth.ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveScript.HealthChange == true)
        {
            SaveScript.HealthChange = false;
            HealthText.text = SaveScript.PlayerHealth.ToString() + "%";
        }

        if(SaveScript.PlayerHealth <= 0f)
        {
            SaveScript.PlayerHealth = 0;

            DeathPanel.gameObject.SetActive(true);
        }
    }
}
