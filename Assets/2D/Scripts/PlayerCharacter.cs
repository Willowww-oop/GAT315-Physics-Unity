using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] CharacterController2D characterController;
    [SerializeField] AnimationEventRouter animationEventRouter;
    [SerializeField] GameObject meleeWeaponL;
    [SerializeField] GameObject meleeWeaponR;
    [SerializeField] ObserverExample observerExample;

    
}
