using UnityEngine;

public class FinishScript : MonoBehaviour
{
    [SerializeField] private GameObject _uiCamera;
    [SerializeField] private GameObject _menuCanvas;
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider zone)
    {
        if (zone.gameObject.CompareTag("Player"))
        {
            _menuCanvas.SetActive(false);
            _uiCamera.SetActive(true);
        }
    }
}
