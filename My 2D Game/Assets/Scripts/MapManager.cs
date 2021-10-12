using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public Map_Movement scripty;

    public transManager tm;

    private void Start()
    {
        Transform[] tileChildren = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            tileChildren[i] = transform.GetChild(i);
        }

        foreach(Transform childT in tileChildren)
        {
            scripty.tileList.Add(new Vector2(childT.position.x,childT.position.y), childT.tag);
            Debug.Log(childT.position + childT.tag);
        }

    }

    /*
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
    */


    public void mapLogic(string tileName)
    {
        switch (tileName)
        {
            case "Plains":
                Debug.Log(Plains.name);
                if (Random.value >= Plains.natEncounterrate) { tm.PlainsEncounter(); }
                break;

            case "Grass":
                Debug.Log(Grass.name);
                if (Random.value >= Plains.natEncounterrate) { tm.GrassEncounter(); }
                break;

            case "Path":
                Debug.Log(Path.name);
                break;

            case "Woods":
                Debug.Log(Woods.name);
                break;

            default:
                Debug.Log("OOPSIES");
                break;
        }
    }


}
