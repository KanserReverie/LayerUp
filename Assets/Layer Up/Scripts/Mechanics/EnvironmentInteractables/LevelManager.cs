using Layer_Up.Scripts.Utility;
using UnityEngine;
using UnityEngine.Assertions;
namespace Layer_Up.Scripts.Mechanics.EnvironmentInteractables
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject baseLayer;
        
        [SerializeField] private GameObject [] layers;
        [SerializeField] private GameObject [] levelGoals;

        [SerializeField] private int currentLevel;
        
        private void Awake()
        {
            Assert.IsNotNull(baseLayer);
            foreach (GameObject layer in layers) Assert.IsNotNull(layer);
            Assert.IsTrue(layers.Length + 1 == levelGoals.Length);
        }
        
        private void Start()
        {
            currentLevel = 1;
            foreach (GameObject levelGoal in levelGoals)
            {
                levelGoal.gameObject.SetActive(false);
            }
            levelGoals[currentLevel-1].gameObject.SetActive(true);
        }
        
        public void NextLevel()
        {
            Debug.Log($"currentLevel <= layers.Length || {currentLevel} <= {layers.Length}");
            
            if (currentLevel <= layers.Length)
            {
                Debug.Log($"Deactivate Layer {currentLevel}");
                layers[currentLevel - 1].gameObject.SetActive(false);
                levelGoals[currentLevel - 1].gameObject.SetActive(false);
                levelGoals[currentLevel].gameObject.SetActive(true);
                currentLevel++;
            }
            else if (currentLevel > layers.Length)
            {
                Victory();
            }
        }

        private void Victory()
        {
            CommonlyUsedStaticMethods.OpenSceneWithSceneName("Main Menu");
        }

        private void OnGUI()
        {
            GUILayout.Label($"Level {currentLevel}", new GUIStyle("box"));
            if (currentLevel <= layers.Length)
            {
                if (GUILayout.Button("Next Level"))
                {
                    NextLevel();
                }
            }
            else if (currentLevel > layers.Length)
            {
                if (GUILayout.Button("Complete Game"))
                {
                    Victory();
                }
            }
        }

        public static void StartNextLevel()
        {
            LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
            levelManager.NextLevel();
        }
    }
}
