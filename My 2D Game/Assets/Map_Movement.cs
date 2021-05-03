using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Movement : MonoBehaviour
{

    private bool isMoving;
    private Vector3 originalPos;
    private Vector3 targetPos;
    private float timeToMove = 0.2f;
    private float elapsedTime;

    private void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                StartCoroutine(Move(Vector3.up));
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(Move(Vector3.left));
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                StartCoroutine(Move(Vector3.down));
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine(Move(Vector3.right));
            }
        }   
    }

    private IEnumerator Move(Vector3 direction)
    {
        isMoving = true;

        elapsedTime = 0f;
        originalPos = transform.position;
        targetPos = originalPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originalPos, targetPos, elapsedTime / timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }


}
