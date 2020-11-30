using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocoMotion : MonoBehaviour
{
    public Transform player;
    public GameObject playerObject;
    private float height;


    public void Start()
    {
        height = player.position.y;
    }

    public void teleportPlayer(Vector3 objectPosition)
    {
        player.position = new Vector3(objectPosition.x, (height + objectPosition.y), objectPosition.z);
    }

    public Vector3 teleportObject(Vector3 objectPosition)
    {
        return new Vector3(player.position.x, (height / 2), player.position.z + 2);
    }

    public void assignObject(GameObject otherObject, Material material)
    {
        playerObject.GetComponent<MeshFilter>().mesh = otherObject.GetComponent<MeshFilter>().mesh;
        playerObject.GetComponent<MeshRenderer>().material = material;
        playerObject.transform.localScale = otherObject.transform.localScale;

        otherObject.SetActive(false);

    }
}
