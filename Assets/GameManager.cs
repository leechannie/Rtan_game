using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public int Score = 0;
    public PlayerHealth player;

    public void GameOver()
    {
        Invoke("GameOver_", 2);
    }

    public void GameOver_()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void Awake()
    {
        I = this;
    }

    public void RevivePlayer()
    {
        player.OnRevival();
    }
}