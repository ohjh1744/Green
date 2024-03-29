using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindHiddenPoint : MonoBehaviour
{
    private List<GameObject> gameObjects;
    public GameObject blur;
    // Start is called before the first frame update
    void Start()
    {
        gameObjects = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            gameObjects.Add(transform.GetChild(i).gameObject);
        }

        foreach (var item in gameObjects)
        {
            item.SetActive(false);
        }

        var sel_num = Random.Range(0, gameObjects.Count);

        gameObjects[sel_num].gameObject.SetActive(true);
        blur.transform.SetParent(gameObjects[sel_num].transform);
        blur.transform.localPosition = Vector3.zero;
    }


}
