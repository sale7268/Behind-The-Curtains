using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModSelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    [Header("Facts UI")]
    [SerializeField] private GameObject GreenlandShark;
    [SerializeField] private GameObject Honey;
    [SerializeField] private GameObject Trees;

    public bool keyCollected = false;

    private Transform _selection;
    // Start is called before the first frame update
    void Start()
    {
        Screen.lockCursor = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if(selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                defaultMaterial = selectionRenderer.material;
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    if(selection.gameObject.name == "RuleBook")
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            Greenlandshark();
                            Destroy(selection.gameObject);
                        }
                    }
                    if (selection.gameObject.name == "Chest")
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            TreesF();
                            Destroy(selection.gameObject);
                        }
                    }
                    if (selection.gameObject.name == "PaperScroll")
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            HoneyF();
                            Destroy(selection.gameObject);
                        }
                    }
                }
                _selection = selection;
            }
            
        }
    }

    private void Greenlandshark()
    {
        Time.timeScale = 0;
        Screen.lockCursor = false;
        GreenlandShark.SetActive(true);
    }

    private void HoneyF()
    {
        Time.timeScale = 0;
        Screen.lockCursor = false;
        Honey.SetActive(true);
    }
    private void TreesF()
    {
        Time.timeScale = 0;
        Screen.lockCursor = false;
        Trees.SetActive(true);
    }


}
