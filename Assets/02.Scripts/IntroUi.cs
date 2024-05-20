using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroUi : MonoBehaviour
{
    public Sprite[] characterImage;

    public Image selectedcharacter;

    public void ChoiceCharacter(int num)
    {
        selectedcharacter.sprite = characterImage[num];
        DataManager.instance.characterNum = num;
    }
}
