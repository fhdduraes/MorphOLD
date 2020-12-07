using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Translation : MonoBehaviour
{
    public Text text;
    public string textid;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        Translate();
    }

    private void Translate()
    {
        if(GlobalVariables.language == "ptbr")
        {
            text.text = textid;
        }
        else if(GlobalVariables.language == "en")
        {
            if(textid == "Fechar a porta")
            {
                text.text = "Close the door";
            }

            else if (textid == "Abrir a porta")
            {
                text.text = "Open the door";
            }

            else if (textid == "Fechar a gaveta")
            {
                text.text = "Close the drawer";
            }

            else if (textid == "Abrir a gaveta")
            {
                text.text = "Open the drawer";
            }

            else if (textid == "Novo Jogo")
            {
                text.text = "New Game";
            }

            else if (textid == "Tradução")
            {
                text.text = "Translation";
            }

            else if (textid == "Apagar a luz")
            {
                text.text = "Turn off the light";
            }

            else if (textid == "Acender a luz")
            {
                text.text = "Turn on the light";
            }

            else if (textid == "Desligar o notebook")
            {
                text.text = "Turn off the notebook";
            }

            else if (textid == "Ligar o notebook")
            {
                text.text = "Turn on the notebook";
            }

            else if (textid == "Verificar o celular")
            {
                text.text = "Check cellphone";
            }

            else if (textid == "Fechar")
            {
                text.text = "Close";
            }

            else if (textid == "Parece que esse é o último")
            {
                text.text = "It looks like this is the last one";
            }

            else if (textid == "Não quero dormir agora")
            {
                text.text = "I don't want to sleep now";
            }

            else if (textid == "Fechar o frigobar")
            {
                text.text = "Close the fridge";
            }

            else if (textid == "Abrir o frigobar")
            {
                text.text = "Open the fridge";
            }

            else if (textid == "Abrir o frigobar")
            {
                text.text = "Open the fridge";
            }

            else if (textid == "Não quero sair agora")
            {
                text.text = "I don't want to leave now";
            }

            else if (textid == "Desligar a torneira")
            {
                text.text = "Turn off the tap";
            }

            else if (textid == "Ligar a torneira")
            {
                text.text = "Turn on the tap";
            }

            else if (textid == "Está trancada")
            {
                text.text = "It's locked";
            }

            else if (textid == "Ligar a tv")
            {
                text.text = "Turn on the tv";
            }

            else if (textid == "Tomar o último remédio (Y/N)")
            {
                text.text = "Take the last medicine (Y/N)";
            }

            else
            {
                text.text = textid;
            }
        }
    }
}
