using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheStupiestAI : MonoBehaviour
{
    [SerializeField] GameObject TargetObject;
    Transform enemy;
    Rigidbody2D enemyRG;
    private void Start()
    {
        enemy = this.transform;
        enemyRG = this.GetComponent<Rigidbody2D>();
        TargetObject = GameObject.Find("Player");
    }

    [SerializeField] float speed = 5f;

    private void FixedUpdate()
    {
        if((enemy.position.y - TargetObject.transform.position.y >0.05f ||TargetObject.transform.position.y - enemy.position.y > 0.05f) && (enemy.position.x - TargetObject.transform.position.x > 0.05f || TargetObject.transform.position.x - enemy.position.x > 0.05f))
        {
            enemy.transform.position = Vector2.MoveTowards(enemy.position, new Vector2(TargetObject.transform.position.x + 0.5f , TargetObject.transform.position.y + 0.5f) , speed * Time.fixedDeltaTime);
        }

        if(enemy.position.x - TargetObject.transform.position.x < 0 && enemy.localScale.x <0)
        {
            Vector3 local = enemy.localScale;
            local.x *= -1;
            enemy.localScale =local ;
        }
        else if ( TargetObject.transform.position.x - enemy.position.x  < 0 && enemy.localScale.x > 0)
        {
            Vector3 local = enemy.localScale;
            local.x *= -1;
            enemy.localScale = local;
        }



    }

}
