using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float force = 1000f;
    private Rigidbody rBody;
    // Start is called before the first frame update
    void Start()
    {
        this.rBody = this.GetComponent<Rigidbody>();
        this.rBody.AddForce(this.transform.forward * this.force);
    }
}
