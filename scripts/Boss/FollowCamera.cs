using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class FollowCamera : MonoBehaviour
{
    public Transform targetTr;
    private Transform cameraTr;

    [Range(2.0f, 20.0f)]
    public float distance = 8.0f;
    [Range(10.0f, 20.0f)]
    public float height = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.cameraTr = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        this.cameraTr.position = new Vector3(6, height , targetTr.position.z- distance);
        this.cameraTr.LookAt(targetTr.position);
        this.cameraTr.rotation = Quaternion.Euler(27, 0, 0);
    }
}
