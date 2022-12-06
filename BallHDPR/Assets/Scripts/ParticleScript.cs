using System.Collections;
using UnityEngine;
/// <summary>
/// Описывается, как работает ParticleSystem.
/// Вызывается в скрипте CoinPatricle.
/// </summary>
public class ParticleScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem _parctical;
   
    public void StartParticalBurst(GameObject activeObject)
    {
        var em = _parctical.emission;
        em.enabled = true;

        _parctical.Play();
        activeObject.SetActive(false);
    }

    public IEnumerator DestroyObject(GameObject activeObject)
    {
        yield return new WaitForSeconds(1f);
        Destroy(activeObject);
    }
}
