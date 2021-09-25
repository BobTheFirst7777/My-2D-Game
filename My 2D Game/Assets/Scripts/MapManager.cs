using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Map_Movement scripty;

    [SerializeField] private GameObject plainsTile;
    [SerializeField] private GameObject grassTile;


    public void construct(Vector2 pos, string ident)
    {
        switch(ident)
        {
            case "Plains":
                Instantiate(plainsTile, new Vector3(pos.x, pos.y, 0), Quaternion.identity, this.transform);
                break;

            case "Grass":
                Instantiate(grassTile, new Vector3(pos.x, pos.y, 0), Quaternion.identity, this.transform);
                break;

            default:
                Debug.Log("OOPSIES");
                break;
        }
    }

    public void mapLogic()
    {

    }


}
