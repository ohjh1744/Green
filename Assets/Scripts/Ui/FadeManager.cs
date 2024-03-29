using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    private float time;
    private Image img;

    public float PauseTime;
    private bool once; //1���� ����ɼ��ֵ��� -> UIcontrol���� ����޴�â�� Ű�� time.scale�� 0�� �Ǿ���ϴµ� Update�κж����� ����޴�â�� �ѵ� ����x.
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        Time.timeScale = 0f;
        img = GetComponent<Image>();
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        if (img != null)
        {
            for (float i = 1; i >= 0; i -= 0.001f)
            {
                img.color = new Color(0, 0, 0, i);
                yield return new WaitForSecondsRealtime(0.00001f);
            }
            
        }
        yield break;
    }

    private void Update()
    {
        if (time >= PauseTime && once == false)
        {
            Time.timeScale = 1f;
            once = true;
        }
        time += Time.unscaledDeltaTime;
    }
}