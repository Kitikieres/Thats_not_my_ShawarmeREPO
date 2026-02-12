using UnityEngine;

public class RejaSoloAnimacion : MonoBehaviour
{
    public Animator rejaAnimator;

    public void ConfirmarNuevaPartida()
    {
        rejaAnimator.SetTrigger("SubirReja");
    }
}
