using UnityEngine;

public class CoinParticle : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _childrenCoin;
    private ParticleScript _particalScript;

    private void Start()
    {
        _particalScript = _coin.GetComponent<ParticleScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _particalScript.StartParticalBurst(_childrenCoin);
            StartCoroutine(_particalScript.DestroyObject(_coin));
        }
    }
}
