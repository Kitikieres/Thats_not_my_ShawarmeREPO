using UnityEngine;
using TMPro;

public class SimpleDialog : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject dialogPanel;   // Panel del diálogo
    [SerializeField] private TMP_Text dialogText;      // Texto del diálogo

    [Header("Texto")]
    [TextArea(3, 6)]
    [SerializeField] private string dialogMessage;     

    private bool playerInRange = false;

    private void Start()
    {
        dialogPanel.SetActive(false); // Oculto al inicio
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            ShowDialog();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            HideDialog();
        }
    }

    private void ShowDialog()
    {
        dialogPanel.SetActive(true);
        dialogText.text = dialogMessage;
    }

    private void HideDialog()
    {
        dialogPanel.SetActive(false);
    }
}


