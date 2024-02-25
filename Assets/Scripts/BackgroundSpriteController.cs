using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpriteController : MonoBehaviour
{
    [SerializeField] private Sprite[] _backgroundSprite;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private int _currentSprite = 0;
    // Start is called before the first frame update
    void Awake()
    {
        TryGetComponent<SpriteRenderer>(out _spriteRenderer);
        _spriteRenderer.sprite = _backgroundSprite[_currentSprite];
    }
    void OnEnable()
    {
        EnemyContoller.OnEnemyChangeState += ChangeBackgroundSprite;
    }

    void OnDisable()
    {
        EnemyContoller.OnEnemyChangeState -= ChangeBackgroundSprite;
    }
    void ChangeBackgroundSprite()
    {
        if(_currentSprite > 2)
        {
            return;
        }
        _currentSprite++;
        _spriteRenderer.sprite = _backgroundSprite[_currentSprite];
    }
    
    // Update is called once per frame
    
}
