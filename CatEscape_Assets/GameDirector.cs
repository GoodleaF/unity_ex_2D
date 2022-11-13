using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using static System.Net.Mime.MediaTypeNames;

public class GameDirector : MonoBehaviour
{
    GameObject hpGauge;

    // Start is called before the first frame update
    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
    }

    public void DecreaseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
        /* 
        if (this.hpGauge.GetComponent<Image>().fillAmount == 0.0f)
        {
            SceneManager.LoadScene("ClearScene");
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
