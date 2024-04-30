using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;


namespace STORYGAME     //�̸� �浹 ����
{

    public class Enums      //������ Ÿ��
    {
        public enum StoryType       //���丮 Ÿ��
        {
            MAIN,
            SUB,
            SERIAL
        }

        public enum EvenType        //�̺�Ʈ �߻��� üũ
        {
            NONE,
            GoToBattle = 100,
            CheakSTR = 1000,
            CheakDEX,
            CheakINT,
            CHEAKWIS,
            CheakCHA
        }

        public enum ResultType      //�̺�Ʈ ��� ����
        {
            ChangeHp,
            ChangeSp,
            AddExperience,
            GoToShop,
            GoTonextStory,
            GoToRandeomStory,
            GoToEnding
        }
    }

    [System.Serializable]
    public class Stats
    {
        //ü�°� ���ŷ�
        public int hpPoint;
        public int spPoint;

        public int currenHpPoint;
        public int currenSpPoint;
        public int currenXpPoint;

        //�⺻ ���� ���� (D&D)
        public int strngth;         //STR
        public int dexterity;       //DEX
        public int consitiution;    //CON
        public int Intelligence;    //INT
        public int wisdom;          //WIS
        public int charisma;        //CHA
    }

}
