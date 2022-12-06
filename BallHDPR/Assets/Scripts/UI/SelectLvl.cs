using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLvl : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private string _textLevel;
    [SerializeField] private Text _text;
    [SerializeField] private int _select;
    [SerializeField] private Font JazzCreateBubble;
    

    private void Start()
    {
        _text.font = JazzCreateBubble;
        
        switch (_select)
        {
            case 0:
                _text.text = _textLevel + " " + _levelNumber.ToString();
                break;
            case 1:
                _text.text = _textLevel.ToString();
                break;
            case 2:
                _text.text =  _textLevel + " locked";
                gameObject.GetComponent<Button>().interactable = false;
                break;
        }
       
    }

    public void OpenScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        Time.timeScale = 1f;
    }
}
