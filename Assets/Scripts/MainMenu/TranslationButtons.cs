using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TranslationButtons : MonoBehaviour
{

    public void PTBR()
    {
        GlobalVariables.language = "ptbr";
    }

    public void EN()
    {
        GlobalVariables.language = "en";
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
