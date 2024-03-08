using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestMain : MonoBehaviour
{
    public Vector3 destPos;
    [SerializeField]
    private ShieldController shieldController;
    [SerializeField]
    private GameObject shieldGo;

    private void Start()
    {
        this.destPos = new Vector3(2, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            //카메라부터 마우스 클릭 위치로 ray 그리기
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 3f);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                this.destPos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                shieldController.moveSpeed = 70f;
                shieldController.Move(this.destPos);
            }
        }
        
    }

}