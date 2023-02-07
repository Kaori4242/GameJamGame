using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class PLayerSystem : MonoBehaviour
{
    [SerializeField] int Health = 100, bronya = 100 , maxHealth = 100 , maxBronya = 100;
    [SerializeField] float KoefUlta = 1.4f,   DamageByUlta = 1f;

    [SerializeField]TextMeshProUGUI HealthText, maxHealthText, SplashText;
    [SerializeField] Image SplashImage;

    private void Start()
    {
        StartCoroutine(helth());
        UpdateSplash();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log(Convert.ToInt32(Math.Ceiling(DamageByUlta)));
            Health -= Convert.ToInt32(Math.Ceiling(DamageByUlta));
            DamageByUlta *= KoefUlta;
            UpdateHealth();
            UpdateSplash();
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "G3")
        {
            Health -= 1;
            UpdateHealth();
        }
        else if (collision.tag == "G10")
        {
            Health -= 3;
            
            UpdateHealth();
            
        }
        else if (collision.tag == "g100")
        {
            Health -= 15;

            UpdateHealth();

        }


        if (Health <= 0)
        {
            SceneManager.LoadScene(0);
        }

    }
    IEnumerator helth()
    {
        while (true)
        {
            if (maxHealth - Health >= 10)
            {
                Health += 10;
                UpdateHealth();
            }
            yield return new WaitForSeconds(10);
        }
        
    }
    void UpdateHealth()
    {
        HealthText.text = Health.ToString() + "/" + maxHealth.ToString();

        if (Health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    void UpdateSplash()
    {
        SplashText.text = Convert.ToInt32(Math.Ceiling(DamageByUlta)).ToString();
        SplashImage.fillAmount = DamageByUlta / 10;
        if (Health <= 0)
        {
            SceneManager.LoadScene(0);
        }
        
    }


}

