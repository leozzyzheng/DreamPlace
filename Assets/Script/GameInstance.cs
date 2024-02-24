using UnityEngine;

namespace Assets.Script
{
    /// <summary>
    /// 游戏入口
    /// </summary>
    public class GameInstance
    {
        private static GameInstance s_instance;
        public static GameInstance Instance()
        {
            if (s_instance == null)
            {
                Debug.LogError("Haven't created GameInstance yet, check the logic here.");
            }

            return s_instance;
        }

        private static void ClearInstance()
        {
            if (s_instance != null)
            {
                s_instance.Dispose();
                s_instance = null;
            }
        }

        /// <summary>
        /// 在游戏开始的时候自动创建
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnBeforeSceneLoad()
        {
            ClearInstance();
            s_instance = new GameInstance();
        }

        private GameInstacneBehaviour m_behaviour;

        private GameInstance()
        {
            // 创建对应的GameObject，实际的逻辑一般都在GameInstacneBehaviour中完成
            GameObject gameInstance = new GameObject("GameInstance");
            m_behaviour = gameInstance.AddComponent<GameInstacneBehaviour>();
            Object.DontDestroyOnLoad(gameInstance);
        }

        private void Dispose()
        {
        }

        public void OnBehaviourDestroy()
        {
            ClearInstance();
        }
    }
}