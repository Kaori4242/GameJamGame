using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurikenLifeSystem : MonoBehaviour
{
    bool isNeed = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.gameObject.tag != "Grid")
        {
            this.gameObject.transform.parent = collision.gameObject.transform;
            this.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
            this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
        }
        
    }
    IEnumerator DieDelay() {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
