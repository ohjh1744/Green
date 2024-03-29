using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story2_arrow : MonoBehaviour
{
    GameObject explosion;
    void Start()
    {
        //explosion�� stroy2_exp������ �ʿ��� ���������� setactive true��Ű�� ������Ƿ� �������Ÿ� ���� awake���� ���� ����.
        try
        {
            explosion = GameObject.Find("Effect").transform.Find("Explosion").gameObject;
        }
        catch
        {
            Debug.Log("explosion ��ã��");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.name == "Story2_Tank")
        {
            explosion.SetActive(true);
            gameObject.SetActive(false);
        } 
    }
}
