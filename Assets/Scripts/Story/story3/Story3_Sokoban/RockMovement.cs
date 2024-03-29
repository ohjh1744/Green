using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    private float time;
    private bool isMoving;
    private Vector2 targetPos;
    private void Start()
    {
        isMoving = false;
        targetPos = (Vector2)transform.position;
        EditorTagLayerHelper.AddNewTag("Rock");
        gameObject.tag = "Rock";
    }
    private void Update()
    {
        Vector2 dif = targetPos - (Vector2)transform.position;

        if (dif != Vector2.zero)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime);
        }
        else
        {
            isMoving = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isMoving && other.collider.CompareTag("Player"))
        {
            time = Time.time;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (!isMoving && other.collider.CompareTag("Player"))
        {
            if (Time.time - time > 0.3f)
            {
                var targetDir = Snap((targetPos - (Vector2)other.transform.position).normalized);
                RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, targetDir, 1f);
                if (hit.collider == null)
                {
                    Debug.Log("hhh : " + hit.collider);
                    targetPos += targetDir;
                    isMoving = true;
                }
            }
        }
    }

    Vector2 Snap(Vector2 dir)
    {
        float absX = Mathf.Abs(dir.x);
        float absY = Mathf.Abs(dir.y);

        if (absX > absY)
        {
            return dir.x > 0 ? Vector2.right : Vector2.left;
        }
        else if (absX < absY)
        {
            return dir.y > 0 ? Vector2.up : Vector2.down;
        }
        return Vector2.zero;
    }
}
