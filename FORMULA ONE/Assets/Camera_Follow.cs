using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{

    public GameObject gaadi;
    private Vector2 chasePos;




    // Update is called once per frame
    void Update()
    {
        chasePos = new Vector2(gaadi.transform.position.x, gaadi.transform.position.y);
        gameObject.transform.position = new Vector3(chasePos.x, chasePos.y, -10);
    }
}
