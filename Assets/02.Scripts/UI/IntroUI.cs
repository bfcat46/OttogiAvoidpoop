using UnityEngine;
using UnityEngine.UI;

public class IntroUI : MonoBehaviour
{
    public Sprite[] CharacterImage;

    public Image SelectedCharacter;

    private void Awake()
    {
        if (DataManager.Instance != null)
        {
            SelectedCharacter.sprite = CharacterImage[DataManager.Instance.CharacterNum];
        }
    }

    public void ChoiceCharacter(int num)
    {
        SelectedCharacter.sprite = CharacterImage[num];
        DataManager.Instance.CharacterNum = num;
    }
}