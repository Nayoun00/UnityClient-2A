using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class ExEnemy : MonoBehaviour
{
    //적이 플레이어에 주는 피해량
    private int damage = 20;
    public ExPlayer TargetPlayer;

    //플레이어에게 피해를 줄 때 호출되는 함수
    public void AttackPlayer(ExPlayer player)
    {
        //플레이어에게 피해를 준다.
        player.TakeDamage(damage);
        Debug.Log("플레이어 공격.");
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AttackPlayer(TargetPlayer);
        }
    }
}
