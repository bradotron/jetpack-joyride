using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  public static GameController instance;
  public GameObject gameOverText;
  public Text scoreText;
  public bool gameOver;
  public float scrollSpeed = -1.5f;

  private int score = 0;

  // Awake precedes Start, so we need this to be active before Start
  void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    else if (instance != this)
    {
      Destroy(gameObject);
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (gameOver && Input.GetKeyDown(KeyCode.Space))
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }

  public void AstronautScored()
  {
    if (!gameOver)
    {
      score++;
      scoreText.text = "Score: " + score.ToString();
    }
  }

  public void AstronautDied()
  {
    gameOverText.SetActive(true);
    gameOver = true;
  }
}
