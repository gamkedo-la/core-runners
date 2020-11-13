using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MusicData))]
public class MusicDataEditor : Editor
{
    MusicData data;
    Vector2 pos;
    bool displayData;

    public void OnEnable()
    {
        data = (MusicData)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (data.beats.Count == 0)
        {
            EditorGUILayout.HelpBox("Empty Music Track Data", MessageType.Info);

            if (GUILayout.Button("Generate Beats", EditorStyles.miniButton))
                data.CreateBeatList();
        }
        else
        {
            if (GUILayout.Button("Reset Beats", EditorStyles.miniButton))
                data.CreateBeatList();
        }

        displayData = EditorGUILayout.Foldout(displayData, "Display Beats");
        if (displayData)
        {
            pos = EditorGUILayout.BeginScrollView(pos);

            for (int i = 0; i < data.beats.Count; i++)
            {
                EditorGUILayout.LabelField("Beat# " + i.ToString());
                data.beats[i] = EditorGUILayout.IntSlider(data.beats[i], -1, data.GetEventTypesRange() - 1);
            }

            EditorGUILayout.EndScrollView();
        }

        EditorUtility.SetDirty(data);
    }
}
