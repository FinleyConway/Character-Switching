using UnityEngine;

public abstract class PlayableCharacter : MonoBehaviour
{
    protected GameObject CurrentCharacter;

    protected void Start()
    {
        CharacterSwitchManager.OnCharacterSwitch += OnCharacterSwitch;
    }

    protected void OnDestroy()
    {
        CharacterSwitchManager.OnCharacterSwitch -= OnCharacterSwitch;
    }

    /// <summary>
    /// Attempt to possess this character
    /// </summary>
    public virtual void Command() { }

    protected abstract void PlayerControl();

    protected abstract void AIControl();

    protected virtual void OnCharacterSwitch(GameObject obj)
    {
        CurrentCharacter = obj;
    }
}
