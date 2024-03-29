
using UnityEngine;

public class OtherHealingEffectControl : MonoBehaviour
{
    public Animator anim;
    [HideInInspector]
    public Vector2 createPos;

    private void OnEnable()
    {
        if (TryGetComponent<Animator>(out anim))
        {
            anim.enabled = false;
        }
    }
    public void CreateEffect()
    {
        transform.position = createPos;
        if (TryGetComponent<Animator>(out anim))
        {
            anim.enabled = true;
        }
    }

    public void EndEffect()
    {
        anim.enabled = false;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        anim.enabled = false;
    } //�ִϸ��̼� �������� �״� ��쿡 anim�ʱ�ȭ ������ߵ�
}
