using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Soul : MonoBehaviour
{
    #region ATTRIBUTES

    //public 
    [Header("Soul Data")]
    public SoulData data;

    [Header("Target tag")]
    public string targetTag = "Player"; //can be change to a "boat" tag 

    //private
    private AudioSource audioS;
    private bool canMove = true;
    private float proximity;

    //protected
    protected float currentHealth;
    protected GameObject target;
    protected Animator anim;
    protected Rigidbody2D rb;
    protected GameObject model;
    #endregion

    #region METHODS

    private void InitilizeData() //initialize the data outside the data holder
    {
        
        model = transform.GetChild(0).gameObject;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag(targetTag);
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
        audioS.PlayOneShot(data.deathScreamClip);
        Destroy(gameObject,data.destroyDelay);
    }

    private void checkProximity()
    {
        proximity = Vector2.Distance(transform.position, target.transform.position);
        if (proximity <= data.stopRadius) canMove = false;

    }

    private void Move() { if (canMove) MoveTowardsTarget(target); }

    public void TakeDamage(float amount)
    {
        if (currentHealth <= 0) OnDeath();
        else
        {
            //play hurt animation
            audioS.PlayOneShot(data.hurtClip);
            currentHealth -= amount;
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
