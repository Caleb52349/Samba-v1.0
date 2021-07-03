using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextLevelDoor : MonoBehaviour
{
    public string nextLevelName;
    public Text InputText;



    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            InputText.text = ("[E] to Enter");
            if (Input.GetKey("e"))
            {
                Application.LoadLevel(nextLevelName);
            }


        }

    }
        void OnTriggerStay2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                InputText.text = ("[E] to Enter");
                if (Input.GetKey("e"))
                {
                    Application.LoadLevel(nextLevelName);
                }
            }

        }
        void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                InputText.text = ("  ");
            }
        }

    }


            

