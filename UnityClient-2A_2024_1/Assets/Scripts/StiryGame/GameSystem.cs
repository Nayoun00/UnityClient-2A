using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using UnityEngine.UIElements;
using STORYGAME;
using UnityEngine.UI;
using TMPro;

namespace STORYGAME
{
#if UNITY_EDITOR
    [CustomEditor(typeof(GameSystem))]

    public class GameSystemEditor : Editor                  //유니티 에디터를 상속
    {
        public override void OnInspectorGUI()               //인스펙터 함수를 재정의
        {
            base.OnInspectorGUI();                          //기존 인스펜터를 가져와서 실행

            GameSystem gameSystem = (GameSystem)target;     //게임 시스템 스크립트 타켓을 설정

            if(GUILayout.Button("Reset Stroy Models"))      //버튼을 생성
            {
                gameSystem.ResetStoryModels();
            }

            if(GUILayout.Button("Assing Text Component by Name"))   //버튼을 생성(UI 컴포넌트를 불러온다)
            {
                //오브젝트 이름으로 Text 컴포넌트 찾기
                GameObject textObject = GameObject.Find("StoryTextUI");
                if(textObject != null)
                {
                    Text textComponent = textObject.GetComponent<Text>();
                    if(textComponent != null)
                    {
                        //Text Component 할당
                        gameSystem.textComponent = textComponent;
                        Debug.Log("Text Component assigned Successfully");
                    }

                }
            }
        }

    }
#endif
}

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;          //간단한 싱글톤 화
    public Text textComponent = null;

    public float delay = 0.1f;
    public string fullText;
    public string currentText = "";

    public enum GAMESTAGE
    {
        STORYSHOW,
        WAITSELECT,
        STORYEND,
        ENDMODE
    }

    public GAMESTAGE currentStage;
    public StoryTableObject[] storyModels;
    public StoryTableObject currentModels;
    public int currentStoryIndex;
    public bool showStory = false;

    private void Awake()
    {
        instance = this;
    }

    public void Start()                    //게임 시작시
    {
        StartCoroutine(ShowText());        //텍스트를 보여준다
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) StoryShow(1);          //Q 키를 누르면 1번 스토리
        if (Input.GetKeyDown(KeyCode.W)) StoryShow(2);          //W 키를 누르면 1번 스토리
        if (Input.GetKeyDown(KeyCode.E)) StoryShow(3);          //E 키를 누르면 1번 스토리

        if (Input.GetKeyDown(KeyCode.Space))
        {
            delay = 0.0f;
        }
    }

    public void StoryShow(int number)
    {
        if(!showStory)
        {
            currentModels = FindStoryModel(number);                 //스토리 모델을 번호로 찾아서
            delay = 0.0f;
            StartCoroutine(ShowText());                             //루틴을 실행 시킨다
        }
    }

    StoryTableObject FindStoryModel(int number)                 //스토리 모델 번호를 찾는 함수
    {
        StoryTableObject tempstoryModels = null;                //temp 미리 저장 해놓을 변수를 선언
        for(int i = 0; i < storyModels.Length; i++)             //버튼으로 받아온 리스트를 for문으로 검사하여
        {
            if (storyModels[i].storyNumber == number)           //숫자가 같은 경우
            {
                tempstoryModels = storyModels[i];               //미리 선언해 놓은 변수에 넣고
                break;                                          //for 문을 빠져 나온다
            }
        }
        return tempstoryModels;                                 //스토리 모델을 돌려준다
    }

    IEnumerator ShowText()
    {
        showStory = true;
        for (int i = 0; i <= currentModels.storyText.Length; i++)
        {
            currentText = currentModels.storyText.Substring(0, i);
            textComponent.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(delay);
        showStory = false;
    }

#if UNITY_EDITOR
    [ContextMenu("Reset Story Models")]

    public void ResetStoryModels()
    {
        storyModels = Resources.LoadAll<StoryTableObject>("");  //Resources 폴더 아래 모든 StoryModel 불러오기
    }
#endif

}