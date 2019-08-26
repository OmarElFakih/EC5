using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caronte : MonoBehaviour
{

    public float attackRate;

    [SerializeField]
    private ParticleSystem _slashParticle = null;

    [SerializeField]
    private Transform _slashTransform = null;

    [SerializeField]
    private AudioClip[] _swingClips = null;

    private Animator _animator = null;

    private bool _isFacingLeft = true;

    private Vector3 _fp = Vector3.zero;
    private Vector3 _lp = Vector3.zero;

    private float _dragDistance = 0f;

    private float _nextAttack = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _dragDistance = Screen.height * 15 / 100;
        _animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //mobile
#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                _fp = touch.position;
                _lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                _lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended && Time.time > _nextAttack)
            {
                _lp = touch.position;

                if (Mathf.Abs(_lp.x - _fp.x) > _dragDistance || Mathf.Abs(_lp.y - _fp.y) > _dragDistance)
                {
                    _lp = Camera.main.ScreenToWorldPoint(_lp);

                    float _mBlend = (_lp.y >= transform.position.y) ? 1f : 0f;

                    if (_lp.x <= transform.position.x && !_isFacingLeft)
                    {
                        Flip();
                        _isFacingLeft = true;
                    }

                    if (_lp.x > transform.position.x && _isFacingLeft)
                    {
                        Flip();
                        _isFacingLeft = false;
                    }

                    Vector3 _mDirection = _lp - _slashTransform.position;
                    float angle = Mathf.Atan2(_mDirection.y, _mDirection.x) * Mathf.Rad2Deg;
                    _slashTransform.eulerAngles = Vector3.forward * angle;

                    _animator.SetFloat("Blend", _mBlend);
                    _animator.SetTrigger("Attack");

                    _nextAttack = Time.time + attackRate;

                }


            }
            
        } 
#endif
        //mobile


#if UNITY_STANDALONE || UNITY_WEBGL
        //other
        if (Input.GetMouseButtonDown(0) && Time.time > _nextAttack)
        {
            Vector3 _mousePoint = Input.mousePosition;
            _mousePoint = Camera.main.ScreenToWorldPoint(_mousePoint);

            float blend = (_mousePoint.y >= transform.position.y) ? 1f : 0f;

            if (_mousePoint.x <= transform.position.x && !_isFacingLeft)
            {
                Flip();
                _isFacingLeft = true;
            }

            if (_mousePoint.x > transform.position.x && _isFacingLeft)
            {
                Flip();
                _isFacingLeft = false;
            }

            Vector3 _slashDirection = _mousePoint - _slashTransform.position;
            float angle = Mathf.Atan2(_slashDirection.y, _slashDirection.x) * Mathf.Rad2Deg;
            _slashTransform.eulerAngles = Vector3.forward * angle;

            _animator.SetFloat("Blend", blend);
            _animator.SetTrigger("Attack");

            _nextAttack = Time.time + attackRate;
        }
#endif
        //other
    }


    private void Flip()
    {
        Vector3 _scale = transform.localScale;
        _scale.x *= -1;
        transform.localScale = _scale;
    }

    public void PlaySwing()
    {
        int index = Random.Range(0, _swingClips.Length);
        AudioSource.PlayClipAtPoint(_swingClips[index], Camera.main.transform.position);
    }


    public void Slash()
    {
        _slashParticle.Play();
    }
}
