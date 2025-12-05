using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;


namespace FastGameDev.Editor
{
    [InitializeOnLoad]
    public static class PlayModeModifier
    {
        static PlayModeModifier()
        {
            // PlayModeStateChanged 回调
            EditorApplication.playModeStateChanged += OnPlayModeChanged;
        }

        static void OnPlayModeChanged(PlayModeStateChange state)
        {
            var config = PlayModeConfig.instance;
            if(config == null || !config.isActive) return;
            
            // 编辑器将进入 Play
            if (state == PlayModeStateChange.ExitingEditMode)
            {
                if (config == null || config.entryScene == null)
                    return;

                string entryScenePath = AssetDatabase.GetAssetPath(config.entryScene);
                if (string.IsNullOrEmpty(entryScenePath))
                    return;

                // 如果当前编辑的场景未保存，提示保存
                if (EditorSceneManager.GetActiveScene().isDirty)
                {
                    if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                    {
                        Debug.Log("取消进入播放模式（因为当前场景未保存）");
                        EditorApplication.isPlaying = false;
                        return;
                    }
                }

                // 切换到入口场景
                EditorSceneManager.OpenScene(entryScenePath);
                Debug.Log($"进入 PlayMode, 自动切换到入口场景: {config.entryScene.name}");
            }
        }
    }
}