using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldCamera : MonoBehaviour
{
    public Transform playerPos;

    private void Update()
    {
        this.transform.position = new Vector3(playerPos.position.x, playerPos.position.y, this.transform.position.z);
    }
}
