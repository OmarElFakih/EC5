using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRotator : MonoBehaviour
{
    private ParticleSystem _ps = null;

    // Start is called before the first frame update
    void Start()
    {
        _ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        float _rot = transform.rotation.eulerAngles.z;
        var main = _ps.main;
        main.startRotation = -(_rot * Mathf.Deg2Rad);
    }
}
