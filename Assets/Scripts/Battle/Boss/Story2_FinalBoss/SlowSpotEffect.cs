using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSpotEffect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {

            if (other.transform.TryGetComponent<PlayerMovement>(out PlayerMovement mv))
            {
                mv.Speed /= 1.5f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (other.transform.TryGetComponent<PlayerMovement>(out PlayerMovement mv))
            {
                mv.Speed *= 1.5f;
            }
        }
    }
    private float time;
    public float life_time = 3f;
    private void Awake()
    {
        time = Time.time;
    }

    private void Update()
    {
        if (Time.time - time > life_time)
        {
            Destroy(gameObject);
        }
    }
}
