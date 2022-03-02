using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    GameObject tapPanel;
    GameObject gameOverPanel;
    GameObject successPanel;
    GameObject gameStatusPanel;
    TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        tapPanel = transform.GetChild(0).gameObject;
        gameOverPanel = transform.GetChild(1).gameObject;
        successPanel = transform.GetChild(2).gameObject;
        gameStatusPanel = transform.GetChild(3).gameObject;

        scoreText = gameStatusPanel.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
        {
            Debug.Log(GameManager.Instance.score.ToString());
            scoreText.text = GameManager.Instance.score.ToString();
        }


        if (GameManager.Instance.gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            gameStatusPanel.SetActive(false);
        }
        if (Input.GetMouseButton(0))
        {
            GameManager.Instance.isGameStarted = true;
            tapPanel.SetActive(false);
            gameStatusPanel.SetActive(true);
        }
        if (GameManager.Instance.isLevelFinished)
        {
            gameStatusPanel.SetActive(false);
            successPanel.SetActive(true);
        }
    }
}
