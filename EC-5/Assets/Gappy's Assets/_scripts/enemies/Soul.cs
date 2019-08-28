using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[SerializeField]
public class Data
{
    public float health;
    public float damage;
    public int points;
    public float lifeTime = 1.3f;
    public float effectVolume = 0.45f;
    public float stopRadius = 2f;
    public AudioClip hurtClip;
    public AudioClip deathClip;

}

public abstract class Soul : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("data")]
    public Data data;

    [Header("model")]
    public SpriteRenderer sr;

    //private
    private AudioSource audioS;
    private bool canMove = true;
    private float proximity;
    private float currentHealth;

    //protected
    protected GameObject target;
    protected Rigidbody2D rb;
    #endregion

    #region METHODS

    private void InitilizeData() //initialize the data outside the data holder
    {
       
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        currentHealth = data.health;
        audioS = GetComponent<AudioSource>();
        audioS.volume = data.effectVolume;
    }

    protected abstract void MoveTowardsTarget(GameObject target);

    protected virtual void OnDeath()
    {
        //play animation
        //play sound effect
        canMove = false;
        GetComponent<Collider2D>().enabled = false;
        FindObjectOfType<ScoreManager>().Add(data.points);//invoke the add method on the score manager
        audioS.PlayOneShot(data.deathClip);
        Destroy(gameObject,data.lifeTime);
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
        if (proximity <= data.stopRadius) canMove = false;

    }

    private void Move() { if (canMove) MoveTowardsTarget(target); Flip(); }

    public void TakeDamage(float amount)
    {
        if (currentHealth <= 0) OnDeath();
        else
        {
            //play hurt animation
            currentHealth -= amount;
            audioS.PlayOneShot(data.hurtClip);
        }
    }

    //BUILT IN METHODS
    protected virtual void Start() => InitilizeData();

    // Update is called once per frame
    void FixedUpdate()
    {
        checkProximity();
        Move();
    }

    #endregion
}
