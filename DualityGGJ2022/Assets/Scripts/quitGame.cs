using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitGame : MonoBehaviour
{
    public void MenuButton(string name)
    {

        if (name == "exit")
        {
            Application.Quit();
            Debug.Log("Quit mothas");
        }
    }
}
