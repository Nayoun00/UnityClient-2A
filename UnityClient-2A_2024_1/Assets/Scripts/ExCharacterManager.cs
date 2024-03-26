using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ExCharacterManager : MonoBehaviour
{
    public List<ExCharacter> characterList = new List<ExCharacter>();
    //���� ���� Ŭ������ ����ص� ExCharacterFast, ExCharacterUp �ڽ� Ŭ������ List�� �������.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))        //Space Ű�� ������ �ı� �ȴ�.
        {
            for(int i = 0; i < characterList.Count; i++)
            {
                characterList[i].DestroyCharacter();
            }
        }
    }
}
