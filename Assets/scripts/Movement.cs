using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    float Horizontal, vertical;
    [SerializeField] Transform PlayerPers;
    [SerializeField] float VerSpeed = 1f , HorSpeed = 1f  , speed = 10f , DashCD = 1f;
    [SerializeField] Rigidbody2D PlayerRigid;
    Animator PlayerAnimator;
    [SerializeField] Animator ArmsAnimator;
    TrailRenderer PlayerTrails;
    bool canDash = true, isDashing = false;
    [SerializeField] GameObject LeftHand, RightHand, FightArms;
    bool canFight = true;

    [SerializeField] Animator ULTA;
    [SerializeField] GameObject UltaObject;

    bool isRight = true;

    [SerializeField] GameObject shotSuriken;
    [SerializeField] float SurikenSpeed = 10f;
    [SerializeField] int SurikenCount = 5;
    [SerializeField] TextMeshProUGUI SurikenCountText;
    private void Start()
    {
        PlayerTrails = this.GetComponent<TrailRenderer>();
        PlayerAnimator = this.GetComponent<Animator>();
    }
    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerTrails.emitting = true;

            Dash();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canFight)
        {
            canFight = false;
            LeftHand.SetActive(false);
            RightHand.SetActive(false);
            FightArms.SetActive(true);
            ArmsAnimator.CrossFade("FigthReal", 0, 0);
            StartCoroutine(delayAnimFigth());
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            
           
            UltaObject.SetActive(true);
            ULTA.CrossFade("uLTA", 0, 0);
            StartCoroutine(delayAnimUlta());
        }
        if (Input.GetKeyDown(KeyCode.F) && SurikenCount>0)
        {
            var tempSur = Instantiate(shotSuriken, this.transform.position, shotSuriken.transform.rotation);
            if (vertical != 0) {
                tempSur.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, SurikenSpeed*vertical), ForceMode2D.Impulse);
            }
            else if (isRight)
            {
                tempSur.GetComponent<Rigidbody2D>().AddForce(new Vector2(SurikenSpeed , 0), ForceMode2D.Impulse);
            }
            else if (!isRight) {
                tempSur.GetComponent<Rigidbody2D>().AddForce(new Vector2(SurikenSpeed * -1, 0), ForceMode2D.Impulse);
            }
            SurikenCount -= 1;
            SurikenCountText.text = SurikenCount.ToString();
            
        }
        Flip();
    }
    private void FixedUpdate()
    {
        PlayerRigid.velocity = new Vector2(Horizontal * HorSpeed, PlayerRigid.velocity.y);
        PlayerRigid.velocity = new Vector2(PlayerRigid.velocity.x, vertical * VerSpeed);
        
        if(Horizontal!=0 || vertical != 0)
        {
            PlayerAnimator.CrossFade("Walking", 0, 0);
        }
        else if(Horizontal != 0 && vertical != 0)
        {
            PlayerAnimator.CrossFade("Walking", 0, 0);
        }
        else
        {
            PlayerAnimator.CrossFade("Idle", 0, 0);
            ArmsAnimator.CrossFade("IdleArm", 0, 0);
        }
        
    }

    private void Flip()
    {
        if (isRight && Horizontal < 0 || !isRight && Horizontal > 0)
        {
           
            isRight = !isRight;
            Vector3 locals = PlayerPers.transform.localScale;
            locals.x *= -1;
            PlayerPers.localScale = locals;
        }
    }
    private void Dash()
    {
       
        if(Horizontal != 0)
        {
            Vector2 endPoint = new Vector2(transform.position.x + Horizontal * speed, transform.position.y);
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, new Vector2(Horizontal, vertical), speed);

            if(raycastHit2D.collider != null && raycastHit2D.collider.tag != "Player")
            {
                endPoint = raycastHit2D.point;
               
            }
            PlayerRigid.MovePosition(endPoint);
            
        }
        else if (vertical != 0)
        {
            PlayerRigid.MovePosition(new Vector2(transform.position.x , transform.position.y + vertical * speed ));
            
        }
        StartCoroutine(delayINdash());
       
    }

    IEnumerator delayINdash()
    {
        yield return new WaitForSeconds(0.1f);
        PlayerTrails.emitting = false;
        
    }
    IEnumerator delayAnimFigth()
    {
        yield return new WaitForSeconds(0.5f);
        FightArms.SetActive(false);
        LeftHand.SetActive(true);
        RightHand.SetActive(true);
        canFight = true;
    }
    IEnumerator delayAnimUlta()
    {
        yield return new WaitForSeconds(1f);
        UltaObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SC")
        {
            SurikenCount += 1;
            SurikenCountText.text = SurikenCount.ToString();
            Destroy(collision.gameObject);
        }

    }
    
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SC")
        {
            SurikenCount += 1;
            SurikenCountText.text = SurikenCount.ToString();
            Destroy(collision.gameObject);
        }
    }*/

}

