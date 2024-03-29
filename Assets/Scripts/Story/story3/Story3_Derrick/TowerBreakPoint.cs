using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBreakPoint : MonoBehaviour
{
    private bool isPlayerInBox;
    private SpriteRenderer sr;
    private Sprite originSprite;
    public Sprite ClickSprite;
    public Image gauge;
    public TowerBreaker breaker;
    // Start is called before the first frame update
    void Start()
    {
        if (TryGetComponent<SpriteRenderer>(out sr))
        {
            originSprite = sr.sprite;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInBox)
        {
            //시간 보정과 함께 1초당 0.1f씩 게이지 감소 효과
            gauge.fillAmount -= 0.5f * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            sr.sprite = ClickSprite;
            isPlayerInBox = true;
            gauge.transform.parent.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            sr.sprite = originSprite;
            isPlayerInBox = false;
            gauge.fillAmount = 0;
            gauge.transform.parent.gameObject.SetActive(false);
        }
    }

    public void BreakAction(float addPoint)
    {
        if (isPlayerInBox)
        {
            gauge.fillAmount += addPoint;
            if (gauge.fillAmount > 0.99f)
            {
                gauge.fillAmount = 0;
                breaker.UpdatePuzzle(gameObject);

            }
        }
    }

}
