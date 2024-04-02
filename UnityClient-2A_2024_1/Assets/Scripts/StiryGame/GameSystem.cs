using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using UnityEngine.UIElements;
using STORYGAME;

namespace STORYGAME
{
#if UNITY_EDITOR
    [CustomEditor(typeof(GameSystem))]

    public class GameSystemEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GameSystem gameSystem = (GameSystem)target;

            if(GUILayout.Button("Reset Stroy Models"))
            {
                gameSystem.ResetStoryModels();
            }
        }

    }
#endif
}

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;          //간단한 싱글톤 화

    private void Awake()
    {
        instance = this;
    }

    public StoryTableObject[] storyModels;
#if UNITY_EDITOR
    [ContextMenu("Reset Story Models")]

    public void ResetStoryModels()
    {
        storyModels = Resources.LoadAll<StoryTableObject>("");  //Resources 폴더 아래 모든 StoryModel 불러오기
    }
#endif

}