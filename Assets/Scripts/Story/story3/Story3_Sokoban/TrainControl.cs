using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainControl : MonoBehaviour
{
    public bool isPaussd;
    public GameObject TrainTargetSpot;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rock"))
        { isPaussd = true; }
        if (other.gameObject == TrainTargetSpot)
        {
            Win();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Rock"))
        { isPaussd = false; }
    }

    private void Win()
    {
        print("Win!!");
        NpcQuest.questnum = 48;
        NpcQuest.Sokoban_win = 1;
    }
}
