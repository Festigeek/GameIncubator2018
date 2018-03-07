using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class BouttonManager : MonoBehaviour{

    public GameObject loadingScreen;
    public Slider slider;
    public Text progresstext;

    private GameInfo gi;

    private void Start()
    {
        gi = GameInfo.autoRef;
        if (!gi) {
            Debug.LogError("BouttonManager.cs: Can't find GameInfo autoref !");
        }
    }

    public void Loadlvl(string newlvl)
    {
        if(gi.IsEnoughPlayersToStartGame())
        {
            StartCoroutine(LoadAsynchron(newlvl));
        }
    }
    public void LoadlvlMenu(string newlvl)
    {
        StartCoroutine(LoadAsynchron(newlvl));
    }

    IEnumerator LoadAsynchron(string newlvl)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(newlvl);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Round(operation.progress / .9F * 100 ) / 100;
            slider.value = progress;
            progresstext.text = progress * 100f + "%";
            yield return null;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}