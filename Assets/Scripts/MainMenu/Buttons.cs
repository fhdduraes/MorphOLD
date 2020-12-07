using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Slider progressBar;
    public Text progressText;

    private void Start()
    {
        progressBar.gameObject.SetActive(false);

        if(GlobalVariables.language == null)
        {
            GlobalVariables.language = "ptbr";
        }
    }

    public void NewGame()
    {
        progressBar.gameObject.SetActive(true);
        StartCoroutine(LoadScene(2));
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            progressBar.value = progress;
            progressText.text = System.Convert.ToInt16(progress * 100f) + "%";

            yield return null;
        }
    }

    public void TranslationMenu()
    {
        SceneManager.LoadScene(1);
    }

}
