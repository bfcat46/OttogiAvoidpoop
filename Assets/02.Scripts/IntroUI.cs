using UnityEngine;
using UnityEngine.UI;

public class IntroUI : MonoBehaviour
{
    public Sprite[] CharacterImage;

    public Image SelectedCharacter;

    public void ChoiceCharacter(int num)
    {
        SelectedCharacter.sprite = CharacterImage[num];
        DataManager.Instance.CharacterNum = num;
    }
}
