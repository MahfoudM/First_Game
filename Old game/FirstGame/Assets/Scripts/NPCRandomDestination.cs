using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRandomDestination : MonoBehaviour
{
    public int genPos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            genPos = Random.Range(1, 5);
            if (genPos == 4)
            {
                this.gameObject.transform.position = new Vector3(5, 1, -71);
            }
            if (genPos == 3)
            {
                this.gameObject.transform.position = new Vector3(145.8f, 1, -70);
            }
            if (genPos == 2)
            {
                this.gameObject.transform.position = new Vector3(145.8f, 1, 69);
            }
            if (genPos == 1)
            {
                this.gameObject.transform.position = new Vector3(5.83f, 1, 69);
            }
        }
    }
}
