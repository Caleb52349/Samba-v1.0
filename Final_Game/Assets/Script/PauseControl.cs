using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{

    public static bool isGamePaused = false;
 [SerializeField] GameObject pauseMenuCanvas;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           if(isGamePaused)
            {
                ResumeGame();
            }
          
           else
            {
                PauseGame();
                
            }
        }
    }
void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
         isGamePaused = false;

    }
 void PauseGame()
    {
        
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
            isGamePaused = true;
            
      
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
       
    }

