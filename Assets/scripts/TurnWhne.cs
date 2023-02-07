using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnWhne : MonoBehaviour
{
    public List<GameObject> TurnThis= new List<GameObject>();
    private void OnTriggerEntert2D(Collision2D collision)
    {
        Debug.Log("dsad");
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        for(int i =0; i<TurnThis.Count; i++)
        {
            TurnThis[i].SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag != "G5")
        {
            Debug.Log("dsad");
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            for (int i = 0; i < TurnThis.Count; i++)
            {
                TurnThis[i].SetActive(true);
            }
        }
        
    }
}
