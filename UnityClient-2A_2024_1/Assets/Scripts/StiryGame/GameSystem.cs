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

    public class GameSystemEditor : Editor                  //����Ƽ �����͸� ���
    {
        public override void OnInspectorGUI()               //�ν����� �Լ��� ������
        {
            base.OnInspectorGUI();                          //���� �ν����͸� �����ͼ� ����

            GameSystem gameSystem = (GameSystem)target;     //���� �ý��� ��ũ��Ʈ Ÿ���� ����

            if(GUILayout.Button("Reset Stroy Models"))      //��ư�� ����
            {
                gameSystem.ResetStoryModels();
            }

            if(GUILayout.Button("Assing Text Component by Name"))   //��ư�� ����(UI ������Ʈ�� �ҷ��´�)
            {
                //������Ʈ �̸����� Text ������Ʈ ã��
                GameObject textObject = GameObject.Find("StoryTextUI");
                if(textObject != null)
                {
                    Text textComponent = textObject.GetComponent<Text>();
                    if(textComponent != null)
                    {
                        //Text Component �Ҵ�
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
    public static GameSystem instance;          //������ �̱��� ȭ
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

    public void Start()                    //���� ���۽�
    {
        StartCoroutine(ShowText());        //�ؽ�Ʈ�� �����ش�
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) StoryShow(1);          //Q Ű�� ������ 1�� ���丮
        if (Input.GetKeyDown(KeyCode.W)) StoryShow(2);          //W Ű�� ������ 1�� ���丮
        if (Input.GetKeyDown(KeyCode.E)) StoryShow(3);          //E Ű�� ������ 1�� ���丮

        if (Input.GetKeyDown(KeyCode.Space))
        {
            delay = 0.0f;
        }
    }

    public void StoryShow(int number)
    {
        if(!showStory)
        {
            currentModels = FindStoryModel(number);                 //���丮 ���� ��ȣ�� ã�Ƽ�
            delay = 0.0f;
            StartCoroutine(ShowText());                             //��ƾ�� ���� ��Ų��
        }
    }

    StoryTableObject FindStoryModel(int number)                 //���丮 �� ��ȣ�� ã�� �Լ�
    {
        StoryTableObject tempstoryModels = null;                //temp �̸� ���� �س��� ������ ����
        for(int i = 0; i < storyModels.Length; i++)             //��ư���� �޾ƿ� ����Ʈ�� for������ �˻��Ͽ�
        {
            if (storyModels[i].storyNumber == number)           //���ڰ� ���� ���
            {
                tempstoryModels = storyModels[i];               //�̸� ������ ���� ������ �ְ�
                break;                                          //for ���� ���� ���´�
            }
        }
        return tempstoryModels;                                 //���丮 ���� �����ش�
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
        storyModels = Resources.LoadAll<StoryTableObject>("");  //Resources ���� �Ʒ� ��� StoryModel �ҷ�����
    }
#endif

}