using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    [SerializeField]
    private float force = 500f;
    private Rigidbody rBody;
    //[SerializeField]
    //private GameObject bombPointGo;
    // Start is called before the first frame update
    void Start()
    {
        this.rBody = this.GetComponent<Rigidbody>();
        this.rBody.AddForce(this.transform.forward * this.force);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        Vector3 hitPoint = collision.GetContact(0).point;
        //Instantiate(bombPointGo,hitPoint)
    }
}
