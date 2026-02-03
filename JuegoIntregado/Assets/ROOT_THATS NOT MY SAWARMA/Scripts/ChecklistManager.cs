using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChecklistManager : MonoBehaviour
{
    public static ChecklistManager Instance;

    public Toggle[] toggles;

    private HashSet<string> preguntasMarcadas = new HashSet<string>();

    void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        preguntasMarcadas.Clear();

        foreach (var toggle in toggles)
        {
            toggle.isOn = false;
            toggle.onValueChanged.AddListener(
                (value) => OnToggle(toggle, value)
            );
        }
    }

    void OnDisable()
    {
        foreach (var toggle in toggles)
            toggle.onValueChanged.RemoveAllListeners();
    }

    void OnToggle(Toggle toggle, bool activo)
    {
        if (activo)
            preguntasMarcadas.Add(toggle.name);
        else
            preguntasMarcadas.Remove(toggle.name);
    }

  
    public void CerrarChecklist()
    {
        
        gameObject.SetActive(false);

        
        if (preguntasMarcadas.Count == 0)
            return;

        
        NPCChecklist npc = FindObjectOfType<NPCChecklist>();

        if (npc != null)
        {
            npc.ResponderDesdeChecklist(preguntasMarcadas);
        }
    }

    public HashSet<string> ObtenerPreguntas()
    {
        return new HashSet<string>(preguntasMarcadas);
    }
}
