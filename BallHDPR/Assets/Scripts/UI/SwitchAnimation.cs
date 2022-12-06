using UnityEngine;

public class SwitchAnimation : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private int _animation;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void SwitchAnim()
    {
        _anim.SetInteger("SwitchAnimIndex", Random.Range(0, _animation));
        _anim.SetTrigger("Switch");
    }
}
