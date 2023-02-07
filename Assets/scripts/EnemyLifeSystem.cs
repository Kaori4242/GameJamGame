using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyLifeSystem : MonoBehaviour
{
    [SerializeField ]float Health = 100;
    [SerializeField]TextMeshPro HPText;
    [SerializeField] GameObject wallnext;
    [SerializeField] bool isBoss;
    [SerializeField] GameObject healthIma;
    Animator EnemyAnim;

    private void Start()
    {
        healthIma.transform.localScale = new Vector3(Health / 1000, healthIma.transform.localScale.y);
        EnemyAnim = this.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "arms")
        {
            Health -= 5;
           
            DamageAnim();
        }
        if (collision.tag == "G5")
        {
            DamageAnim();
            Health -= 3;
           
        }

        if (Health <= 0)
        {
            if (isBoss)
            {
                wallnext.GetComponent<BoxCollider2D>().isTrigger = true;
            }
            
            Destroy(this.gameObject);
        }

    }
    void DamageAnim() {
        Debug.Log("fasf");
        EnemyAnim.SetTrigger("IsDamage");
        
        healthIma.transform.localScale = new Vector3(Health / 1000 , healthIma.transform.localScale.y) ;
    }
}
