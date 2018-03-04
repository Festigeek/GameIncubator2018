using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
public class PointsCounter : MonoBehaviour {

    public int[] pointsPlayers;
    public int maxScore = 1000;
    public GameObject PrefabCanvasRestart;
    private ActivateWin activateWin;

    private int nbPlayers;
    private readonly int POINTS_FOR_BATTERY;

  
    
	// Use this for initialization
	void Start () {
		for(int i = 0; i < nbPlayers; i++)
        {
            pointsPlayers[i] = 0;
        }
        activateWin = PrefabCanvasRestart.GetComponent<ActivateWin>();
}
	
	public void IncreasePoints(int player) {
        pointsPlayers[player] += POINTS_FOR_BATTERY;

        CheckPoints(pointsPlayers[player], player);
	}

    private void CheckPoints(int score, int player)
    {
        if(score >= maxScore)
        {
            activateWin.WinScreen(player);
        }
    }

}
