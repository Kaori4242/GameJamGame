using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSystem : MonoBehaviour
{
    [SerializeField]GameObject Chest;
    [SerializeField] GameObject SurikensCollect;
    bool InZone = false , isAva = true;
    [SerializeField] Sprite OpenedChest, closedChest;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InZone && isAva) {
            Chest.GetComponent<SpriteRenderer>().sprite = OpenedChest;
            spawnSurikens();
            isAva = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            InZone = true;
        }
         
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            InZone = false;
        }
        
    }

    void spawnSurikens() {

        this.GetComponent<CircleCollider2D>().enabled = false;
        int NumberOfSuriken = Random.Range(1, 6);
        Debug.Log(NumberOfSuriken);
        
        for (int i = 2; i <= NumberOfSuriken+1 ; i++)
        {
            
            if (i % 2 == 0)
            {

                var tempSur = Instantiate(SurikensCollect, new Vector3(this.transform.position.x, this.transform.position.y - i), SurikensCollect.transform.rotation , Chest.transform);
            }
            else {
                var tempSur = Instantiate(SurikensCollect, new Vector3(this.transform.position.x+i, this.transform.position.y ), SurikensCollect.transform.rotation , Chest.transform);
            }
            
        }
    }
       
}
