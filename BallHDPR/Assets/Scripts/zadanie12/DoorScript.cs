using UnityEngine;

namespace Door
{
    public class DoorScript : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        private bool _isOpened;
        private DoorTriggerZone dtz;

        private void Start()
        {
            dtz = GameObject.Find("TriggerZone").GetComponent<DoorTriggerZone>();
            dtz._isActiveButton = GetComponent<DoorTriggerZone>();
            dtz._isActiveButton = false;
        }

        private void Update()
        {
            Open();
        }
        private void Open()
        {
            if (Input.GetKeyDown(KeyCode.E) && dtz._isActiveButton == true)
            {
                _anim.SetBool("IsOpened", _isOpened);
                _isOpened = !_isOpened;
            }
        }
    }
}
