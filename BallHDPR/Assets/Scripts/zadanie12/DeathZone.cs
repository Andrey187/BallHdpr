using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    private int _activeScene;
    private DeathZone _deathZone;
    private ParticleScript _particalScript;
    private GameObject _player;
    private GameObject _playerMesh;

    private void Start()
    {
        _activeScene = SceneManager.GetActiveScene().buildIndex;
        _deathZone = GetComponent<DeathZone>();
        
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerMesh = _player.GetComponentInChildren<MeshRenderer>().gameObject;
        _particalScript = _player.GetComponentInChildren<ParticleScript>();
    }

    private void OnTriggerEnter(Collider zone)
    {
        if(_deathZone.isActiveAndEnabled == true)
        {
            if (zone.gameObject.CompareTag("Player"))
            {
                _particalScript.StartParticalBurst(_playerMesh);
                StartCoroutine(_particalScript.DestroyObject(_player));
                StartCoroutine(Death());
            }
        }
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(_activeScene);
    }
}
