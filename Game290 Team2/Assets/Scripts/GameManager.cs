// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class GameManager : MonoBehaviour
// {
//     [SerializeField]
//     private int nextLevel = 0;

//     [SerializeField]
//     private int goal = 1;

//     private int score = 0;

//     private void Update()
//     {
//         if (score >= goal)
//         {
//             Debug.Log("Level complete!");
//             SceneManager.LoadScene(nextLevel);
//         }
//     }

//     public void AddScore(int amount)
//     {
//         score += amount;
//         Debug.Log("Score: " + score);
//     }
// }
