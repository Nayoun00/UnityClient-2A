using STORYGAME;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Text;

#if UNITY_EDITOR
[CustomEditor(typeof(GameSystem))]
public class GameSystemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameSystem gameSystem = (GameSystem)target;

        if (GUILayout.Button("Reset Story Models"))      //에디터에서 버튼 생성
        {
            gameSystem.ResetStoryModels();
        }
    }

}
#endif
public class GameSystem : MonoBehaviour
{
    public StoryModel[] storyModels;                    //변경된 스토리 모델로 생성

    public static GameSystem instance;                  //간단한 싱글톤화

    private void Awake()                                //Scene이 생성 될 때 코드설정단에서 GameSystem을 싱글톤화
    {
        instance = this;
    }

    public enum GAMESTATE
    {
        STORYSHOW,
        WAITSELECT,
        STORYEND,
        BATTLEMODE,
        BATTLEDONE,
        SHOPMODE,
        ENDMODE
    }

    public Stats stats;
    public GAMESTATE cuurentState;

    public int currentStoryIndex = 1;          //진행되고 있는 스토리 번호

    public void ApplyChoice(StoryModel.Result result)
    {
        switch (result.resultType)
        {
            case StoryModel.Result.ResultType.ChangeHP:
                //stats.currentHpPoint += result.value;
                ChangeState(result);
                break;

            case StoryModel.Result.ResultType.AddExperience:
                ChangeState(result);
                break;

            case StoryModel.Result.ResultType.GoToNextStory:
                currentStoryIndex = result.value;
                StoryShow(currentStoryIndex);
                break;

            case StoryModel.Result.ResultType.GoToRandomStory:
                StoryModel temp = RandomStory();
                StoryShow(temp.storyNumber);
                break;
        }
    }
    public void StoryShow(int number)
    {
        StoryModel tempStoryModel = FindStoryModel(number);

        StorySystem.instance.currentStoryModel = tempStoryModel;
        StorySystem.instance.CoShowText();
    }

    public void ChangeState(StoryModel.Result result)
    {
        if (result.stats.hpPoint > 0) stats.hpPoint += result.stats.hpPoint;
        if (result.stats.spPoint > 0) stats.spPoint += result.stats.spPoint;
        if (result.stats.currentHpPoint > 0) stats.currentHpPoint += result.stats.currentHpPoint;
        if (result.stats.currentSpPoint > 0) stats.currentSpPoint += result.stats.currentSpPoint;
        if (result.stats.currentXpPoint > 0) stats.currentXpPoint += result.stats.currentXpPoint;
        if (result.stats.strength > 0) stats.strength += result.stats.strength;
        if (result.stats.dexterity > 0) stats.dexterity += result.stats.dexterity;
        if (result.stats.consitiution > 0) stats.consitiution += result.stats.consitiution;
        if (result.stats.wisdom > 0) stats.wisdom += result.stats.wisdom;
        if (result.stats.Intelligence > 0) stats.Intelligence += result.stats.Intelligence;
        if (result.stats.charisma > 0) stats.charisma += result.stats.charisma;
    }

    StoryModel RandomStory()
    {
        StoryModel tempStoryModels = null;
        List<StoryModel> StoryModelList = new List<StoryModel>();                 //랜덤을 돌리기 위한 List 생성

        for (int i = 0; i < storyModels.Length; i++)                              //for 문으로 배열 안에 있는 선언한 모델 데이터에서
        {
            if (storyModels[i].storyType == StoryModel.STORYTYPE.MAIN)            //스토리 타입이 Main인 경우에만 해당 List에 추가 
            {
                StoryModelList.Add(storyModels[i]);
            }
        }

        tempStoryModels = StoryModelList[Random.Range(0, StoryModelList.Count)];        //선별한 스토리들 중 List 숫자 만큼 랜덤 값을 돌려서 가져온다.
        currentStoryIndex = tempStoryModels.storyNumber;
        Debug.Log("currentStoryIndex " + currentStoryIndex);

        return tempStoryModels;
    }

    StoryModel FindStoryModel(int number)                    //StoryModel을 되돌려주는 함수 번호로 찾아서 리턴
    {
        StoryModel tempStoryModels = null;

        for (int i = 0; i < storyModels.Length; i++)         //for 문으로 배열 안에 있는 선언한모델 데이터에서
        {                                                    //storyNumber 값이 일치할 경우 임의로 선언한 temp 에 넣어서
            if (storyModels[i].storyNumber == number)
            {
                tempStoryModels = storyModels[i];
                break;
            }
        }
        return tempStoryModels;                             //return 시킨다.
    }

#if UNITY_EDITOR
    [ContextMenu("Reset Story Models")]
    public void ResetStoryModels()
    {
        storyModels = Resources.LoadAll<StoryModel>(""); //Resources 폴더 아래 모든 StoryModel 불러오기
    }
#endif
}
