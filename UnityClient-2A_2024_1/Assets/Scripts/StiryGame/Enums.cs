using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;


namespace STORYGAME     //이름 충돌 방지
{

    public class Enums      //열거형 타입
    {
        public enum StoryType       //스토리 타입
        {
            MAIN,
            SUB,
            SERIAL
        }

        public enum EvenType        //이벤트 발생시 체크
        {
            NONE,
            GoToBattle = 100,
            CheakSTR = 1000,
            CheakDEX,
            CheakINT,
            CHEAKWIS,
            CheakCHA
        }

        public enum ResultType      //이벤트 결과 열거
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
        //체력과 정신력
        public int hpPoint;
        public int spPoint;

        public int currenHpPoint;
        public int currenSpPoint;
        public int currenXpPoint;

        //기본 스텟 설정 (D&D)
        public int strngth;         //STR
        public int dexterity;       //DEX
        public int consitiution;    //CON
        public int Intelligence;    //INT
        public int wisdom;          //WIS
        public int charisma;        //CHA
    }

}
