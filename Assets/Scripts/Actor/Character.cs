using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : PlayableCharacter
{
    public CharacterController Controller { get; private set; }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (CurrentCharacter == gameObject)
        {
            PlayerControl();
        }
        else
        {
            AIControl();
        }
    }

    public override void Command()
    {
        Controller.enabled = true;
        CharacterSwitchManager.OnCharacterSwitch(gameObject);
    }

    protected override void PlayerControl()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal") * 5, 0, Input.GetAxisRaw("Vertical") * 5).normalized;

        Controller.SimpleMove(moveDirection);
    }

    protected override void AIControl()
    {
        print($"{this} I AM A AI!!!");
    }
}
