using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private SoundManager soundManager;
    private GameManager gameManager;
    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2"))
        {
            // if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
            // {

            soundManager.StopSound();
            soundManager.PlaySound(SoundManager.Sounds.Win);
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                
                if (other.CompareTag("Player"))
                {
                    gameManager.winText.text = "PLAYER1 WIN";
                }
                if (other.CompareTag("Player2"))
                {
                    gameManager.winText.text = "PLAYER2 WIN";

                }
            }
            else
            {
                if (other.CompareTag("Player"))
                {
                    gameManager.winText.text = "PLAYER2 WIN";
                }
                if (other.CompareTag("Player2"))
                {
                    gameManager.winText.text = "PLAYER1 WIN";
                }
            }

            Invoke(nameof(Load), 3.0f);

            // }
            //else
            //{
            //    soundManager.PlaySound(SoundManager.Sounds.Win);
            //    SceneManager.LoadScene(0);
            //}

        }
        
    }

    public void Load()
    {
        
        SceneManager.LoadScene(0);
    }

}
