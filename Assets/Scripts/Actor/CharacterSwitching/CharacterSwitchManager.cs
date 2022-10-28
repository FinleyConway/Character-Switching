using System;
using System.Collections;
using UnityEngine;

public class CharacterSwitchManager : MonoBehaviour
{
    [Header("Characters")]
    [SerializeField] private Character[] _characters;

    [Header("Character Switching Time")]
    [SerializeField] private float _switchingTime = 0.1f;
    private int _currentCharacterIndex = 0;
    public static Action<GameObject> OnCharacterSwitch { get; set; }

    private void Start()
    {
        // init the first character
        OnCharacterSwitch?.Invoke(_characters[0].gameObject);
    }

    private void Update()
    {
        // switch character
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(ChangeCharacter());
        }
    }

    private IEnumerator ChangeCharacter()
    {
        yield return new WaitForSeconds(_switchingTime);

        // disable current characters controller
        _characters[_currentCharacterIndex].Controller.enabled = false;

        // moves to the next character
        if (_currentCharacterIndex == _characters.Length - 1)
            _currentCharacterIndex = 0;
        else
            _currentCharacterIndex++;

        // enable the new character controller
        OnCharacterSwitch?.Invoke(_characters[_currentCharacterIndex].gameObject);
        _characters[_currentCharacterIndex].Controller.enabled = true;
    }
}