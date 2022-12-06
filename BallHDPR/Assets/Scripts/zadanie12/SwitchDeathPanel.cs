using UnityEngine;
using UnityEngine.UI;

public class SwitchDeathPanel : MonoBehaviour
{
    [SerializeField] private GameObject _switchTextPanel;
    private DeathZone _deathZone;
    private TextMesh _deathGroundText;
    private bool _isActiveButton;

    private void Start()
    {
        _deathZone = GameObject.Find("DeathGround").GetComponent<DeathZone>();
        _deathGroundText = GameObject.Find("DeathGround").GetComponentInChildren<TextMesh>();
    }

    private void Update()
    {
        Switch();
    }

    private void OnTriggerEnter(Collider zone)
    {
        if (zone.gameObject.CompareTag("Player"))
        {
            UiTextPanel(1);
            _isActiveButton = true;
            Switch();
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

/// <summary>
/// Отключаю/Включаю скрипт на объекте и меняю цвет текста
/// </summary>
    private void Switch()
    {
        if (Input.GetKeyDown(KeyCode.E) && _isActiveButton == true)
        {
            _deathZone.enabled = !_deathZone.enabled;
            if (_deathZone.enabled)
            {
                _deathGroundText.color = Color.red;
            }
            else
            {
                _deathGroundText.color = Color.green;
            }
        }
    }

    private void UiTextPanel(int _select)
    {
        switch (_select)
        {
            case 1:
                _switchTextPanel.SetActive(true);
                break;
            case 2:
                _switchTextPanel.SetActive(false);
                break;
        }

    }
}
