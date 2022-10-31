using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startText;
    public static int numberOfCoins;
    public Text coinsText;
    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;
        gameOver = false;
        Time.timeScale = 1;
        FindObjectOfType<AudioManager>().PlaySound("MainTheme");
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        coinsText.text = "COINS:" + numberOfCoins.ToString();
        
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        
        if (SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startText);
        }
    }
}
