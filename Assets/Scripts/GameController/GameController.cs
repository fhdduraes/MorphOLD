using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    void Start()
    {
        if (GlobalVariables.language == null)
        {
            GlobalVariables.language = "ptbr";
        }
    }

    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}
