using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExParentClass : MonoBehaviour  //��� : ����Ƽ ������Ʈ���� �����ϰ�
{
   //protected�� ����� ������ ���� Ŭ���� �� �Ļ� Ŭ�������� ���� ����
    protected int protectedValue;
}

public class ExChildClass : ExParentClass    //ExParentClass�� ���
{
    private void Start()
    {
        //ExParentClass�� Protected ������ ���� ����
        Debug.Log("Protected Value Form Child Class : " + protectedValue);
    }
}
