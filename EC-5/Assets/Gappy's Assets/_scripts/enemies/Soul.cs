using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public abstract class Soul : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("data")]
    public float health;
    public float damage;
    public float speed;
    public int points;
    public float lifeTime = 1.3f;
    public float effectVolume = 0.45f;
    public float stopRadius = 2f;
    public AudioClip hurtClip;
    public AudioClip deathClip;

    [Header("model")]
    public SpriteRenderer sr;

    //private
    private AudioSource audioS;
    private bool canMove = true;
    private float proximity;


    //protected
    protected GameObject target;
    protected Rigidbody2D rb;
    #endregion

    #region METHODS

    protected abstract void MoveTowardsTarget(GameObject target);

    protected virtual void OnDeath()
    {
        //play animation
        //play sound effect
        canMove = false;
        GetComponent<Collider2D>().enabled = false;
        FindObjectOfType<ScoreManager>().Add(points);//invoke the add method on the score manager
        audioS.PlayOneShot(deathClip);
        Destroy(gameObject,lifeTime);
    }

    private void Flip()
    {
        Vector2 dir = new Vector2(target.transform.position.x - rb.position.x,target.transform.position.y - rb.position.y);
        if (dir.x > 0) sr.flipX = false;
        else sr.flipX = true;
    }

    private void checkProximity()
    {
        proximity = Vector2.Distance(transform.position, target.transform.position);
        if (proximity <= stopRadius) canMove = false;

    }

    private void Move() { if (canMove) MoveTowardsTarget(target); Flip(); }

    public void TakeDamage(float amount)
    {
        if (health <= 0) OnDeath();
        else
        {
            //play hurt animation
            health -= amount;
            audioS.PlayOneShot(hurtClip);
        }
    }

    //BUILT IN METHODS
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        audioS = GetComponent<AudioSource>();
        audioS.volume = effectVolume;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkProximity();
        Move();
    }

    #endregion
}
