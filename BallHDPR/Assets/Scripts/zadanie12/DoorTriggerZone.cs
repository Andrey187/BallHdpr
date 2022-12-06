using UnityEngine;

namespace Door
{
    public class DoorTriggerZone : MonoBehaviour
    {
        [SerializeField] private GameObject _doorTextPanel;
        public bool _isActiveButton;

        private void OnTriggerEnter(Collider zone)
        {
            if (zone.gameObject.CompareTag("Player"))
            {
                UiTextPanel(1);
                _isActiveButton = true;
            }
        }

        private void OnTriggerExit(Collider zone)
        {
            if (zone.gameObject.CompareTag("Player"))
            {
                UiTextPanel(2);
                _isActiveButton = false;
            }
        }

        private void UiTextPanel(int _select)
        {
            switch (_select)
            {
                case 1:
                    _doorTextPanel.SetActive(true);
                    break;
                case 2:
                    _doorTextPanel.SetActive(false);
                    break;
            }

        }
    }
}
