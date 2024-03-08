using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMain : MonoBehaviour
{
    [SerializeField]
    private CJoystick1 joystick1;
    [SerializeField]
    private Player player;
    [SerializeField]
    private BossController bossController;
    private bool isDown;
    // Start is called before the first frame update
    void Start()
    {
        this.joystick1.onDown = () =>
        {
            this.isDown = true;
        };

        this.joystick1.onUp = () =>
        {
            this.isDown = false;
            this.player.Attack();//아래에서 dir=vector3.zero 면 idle 실행하는거 썼는데 왜 여기다가 또 썼을까?
        };
    }

    // Update is called once per frame
    void Update()
    {
        //수평
        var h = this.joystick1.Horizontal;
        //수직
        var v = this.joystick1.Vertical;
        var dir = new Vector3(h, 0, v);
        if (dir != Vector3.zero)
        {
            this.player.Move(dir);
        }
        //else if(dir==Vector3.zero&&isDown==false)
        //this.player.Attack();

    }
}
