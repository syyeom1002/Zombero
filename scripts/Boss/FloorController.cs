using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    [SerializeField]
    private GameObject closeAttackEffect;
    private BossController bossController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("attackPos"))
        {
            
            Vector3 pos = collision.GetContact(0).point;
            Quaternion rot = Quaternion.LookRotation(collision.GetContact(0).point);
            ShowEffect(pos, rot);
        }
    }
    private void ShowEffect(Vector3 pos,Quaternion rot)
    {
        GameObject attackGo=Instantiate(closeAttackEffect, pos, rot);
        Destroy(attackGo, 1f);
    }
}
