using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Movement : MonoBehaviour
{
    [SerializeField]private bool isMoving;
    private Vector3 originalPos;
    private Vector3 targetPos;
    private float timeToMove = 0.2f;
    private float elapsedTime;

    public Dictionary<Vector2, string> tileList;

    public MapManager map;



    private void Awake()
    {
        tileList = new Dictionary<Vector2, string>();
        tileList.Add(new Vector2(0,1), "Plains");
        tileList.Add(new Vector2(0,2), "Grass");
        tileList.Add(new Vector2(0,3), "Plains");
        tileList.Add(new Vector2(0,4), "Grass");
        tileList.Add(new Vector2(0,5), "Plains");
        tileList.Add(new Vector2(0,6), "Grass");

        foreach(KeyValuePair<Vector2,string> pair in tileList)
        {
            map.construct(pair.Key, pair.Value);
        }
    }




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

        switch(tileList[new Vector2(transform.position.x, transform.position.y)])
        {
            case "Plains":
                Debug.Log(Plains.name);
                break;
            case "Grass":
                Debug.Log(Grass.name);
                break;
        }


    }


}
