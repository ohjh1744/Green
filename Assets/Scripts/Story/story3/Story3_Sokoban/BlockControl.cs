using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour
{
    public bool isBlocked = false;
    public int NextPathPointIdx;
    public int EndPathPointIdx;

    private void OnTriggerStay2D(Collider2D other)
    {
        print(other.tag);
        if (other.CompareTag("Rock"))
        {
            isBlocked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Rock"))
        {
            isBlocked = false;
        }
    }
}
