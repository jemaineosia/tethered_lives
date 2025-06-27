using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    public SwitchPlatform switchA, switchB;
    public Animator doorAnimator;

    void Update()
    {
        if (switchA.isPressed && switchB.isPressed)
        {
            doorAnimator.SetTrigger("Open");
        }
    }
}
