using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    [Header("Facts UI")]
    [SerializeField] private GameObject GreenlandShark;
    [SerializeField] private GameObject Honey;
    [SerializeField] private GameObject Trees;
    [SerializeField] private GameObject Teeth;
    [SerializeField] private GameObject Lighter;
    [SerializeField] private GameObject Kneecap;

    [SerializeField] private GameObject Key;
    [SerializeField] private GameObject keyFloatingText;

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
        if (GameObject.Find("ScoreManager").GetComponent<ScoreManager>().scoreCount < 299 && GameObject.Find("ScoreManager").GetComponent<ScoreManager>().cluesCount == 6)
        {
            //TODO: Activate restart button at the bottom right of the screen and pause the game
        }

        if (GameObject.Find("ScoreManager").GetComponent<ScoreManager>().scoreCount >= 300 && GameObject.Find("ScoreManager").GetComponent<ScoreManager>().cluesCount == 6)
        {
            Key.SetActive(true);
        }

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
                    if (selection.gameObject.name == "NoticeBoard")
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            KneecapF();
                            Destroy(selection.gameObject);
                        }
                    }
                    if (selection.gameObject.name == "PaperScroll")
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            LighterF();
                            Destroy(selection.gameObject);
                        }
                    }
                    if (selection.gameObject.name == "Sack")
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            HoneyF();
                            Destroy(selection.gameObject);
                        }
                    }
                    if (selection.gameObject.name == "FlintPistol")
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            TeethF();
                            Destroy(selection.gameObject);
                        }
                    }
                    if (selection.gameObject.name == "rust_key")
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            Destroy(selection.gameObject);
                            KeyF();
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
    private void TeethF()
    {
        Time.timeScale = 0;
        Screen.lockCursor = false;
        Teeth.SetActive(true);
    }
    private void LighterF()
    {
        Time.timeScale = 0;
        Screen.lockCursor = false;
        Lighter.SetActive(true);
    }
    private void KneecapF()
    {
        Time.timeScale = 0;
        Screen.lockCursor = false;
        Kneecap.SetActive(true);
    }

    private void KeyF()
    {
        Instantiate(keyFloatingText, transform.position, Quaternion.identity);
        keyCollected = true;
    }

}
