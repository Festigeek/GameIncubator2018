using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateWin : MonoBehaviour {

    public GameObject menuButton;
    public Button myButton;
    public Text winText;

    private bool end = false;

    public void WinScreen(int player)
    {
        end = true;
        winText.text = "Victory !\n Player " + player.ToString() + " wins";
        menuButton.SetActive(true);
        myButton.Select();
        Invoke("quit", 3f);
    }

    void quit()
    {
        GetComponent<BouttonManager>().LoadlvlMenu("menu");
    }

    private void Update()
    {
        if (end)
            myButton.Select();
    }
}
