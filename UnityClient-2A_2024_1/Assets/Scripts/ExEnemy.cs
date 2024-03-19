using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class ExEnemy : MonoBehaviour
{
    //���� �÷��̾ �ִ� ���ط�
    private int damage = 20;
    public ExPlayer TargetPlayer;

    //�÷��̾�� ���ظ� �� �� ȣ��Ǵ� �Լ�
    public void AttackPlayer(ExPlayer player)
    {
        //�÷��̾�� ���ظ� �ش�.
        player.TakeDamage(damage);
        Debug.Log("�÷��̾� ����.");
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AttackPlayer(TargetPlayer);
        }
    }
}
