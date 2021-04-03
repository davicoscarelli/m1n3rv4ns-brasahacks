using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprites : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] _references;
    [SerializeField] Sprite[] _targetSprite;

    public void UpdateSprite(int score)
    {
        SetSprite(_targetSprite[score / 5]);
    }

    public void SetSprite(Sprite targetSprite)
    {
        for (int i = 0; i < _references.Length; i++)
        {
            
            Debug.Log("entrou");
            _references[i].sprite = targetSprite;
        }
    }
}
