using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLvl : MonoBehaviour
{
    private int _nextSceneLoad;
    private void Start()
    {
        _nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter(Collider zone)
    {
        if(zone.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(_nextSceneLoad);
        }
    }
}
