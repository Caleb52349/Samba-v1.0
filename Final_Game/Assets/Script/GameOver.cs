using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Player ps;
    public string RestartLevelName;

    private void Start()
    {
        
    }
    public void restart()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

      





    }

  
   public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
