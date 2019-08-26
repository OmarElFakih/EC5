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

    }

    protected abstract void MoveTowardsTarget(GameObject target);

    public void OnDeath()
    {
        //play animation
        //play sound effect
        Destroy(gameObject,data.destroyDelay);
    }

    //BUILT IN METHODS
    protected virtual void Start() => InitilizeData();

    // Update is called once per frame
    void FixedUpdate() => MoveTowardsTarget(target);

    #endregion
}
