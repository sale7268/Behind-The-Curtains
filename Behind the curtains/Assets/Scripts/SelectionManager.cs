using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private GameObject RestartUI;

    public bool keyCollected = false;

    public AudioClip hover;
    public AudioSource HoverSource;

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
            Time.timeScale = 0;
            Screen.lockCursor = false;
            Cursor.visible = true;
            RestartUI.SetActive(true);
        }

        if (GameObject.Find("ScoreManager").GetComponent<ScoreManager>().scoreCount >= 300 && GameObject.Find("ScoreManager").GetComponent<ScoreManager>().cluesCount == 6)
        {
            if (!keyCollected)
            {
                Key.SetActive(true);
            }
            
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
                HoverSource.clip = hover;
                HoverSource.Play();
                if (selection.gameObject.name == "TDoor")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        backToLobby();
                    }
                }
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
                            Key.SetActive(false);
                            KeyF();
                        }
                    }
                }
                _selection = selection;
            }
            
        }
    }


    private void backToLobby()
    {
        Debug.Log("BackToLobbyCalled");
        if (keyCollected)
        {
            SceneManager.LoadScene("Lobby");
        }
    }
    private void Greenlandshark()
    {
        Time.timeScale = 0;
        Screen.lockCursor = false;
        Cursor.visible = true;
        GreenlandShark.SetActive(true);
    }

    private void HoneyF()
    {
        Time.timeScale = 0;
        Screen.lockCursor = false;
        Cursor.visible = true;
        Honey.SetActive(true);
    }
    private void TreesF()
    {
        Time.timeScale = 0;
        Screen.lockCursor = false;
        Cursor.visible = true;
        Trees.SetActive(true);
    }
    private void TeethF()
    {
        Time.timeScale = 0;
        Screen.lockCursor = false;
        Cursor.visible = true;
        Teeth.SetActive(true);
    }
    private void LighterF()
    {
        Time.timeScale = 0;
        Screen.lockCursor = false;
        Cursor.visible = true;
        Lighter.SetActive(true);
    }
    private void KneecapF()
    {
        Time.timeScale = 0;
        Screen.lockCursor = false;
        Cursor.visible = true;
        Kneecap.SetActive(true);
    }

    private void KeyF()
    {
        Instantiate(keyFloatingText, transform.position, Quaternion.identity);
        keyCollected = true;
    }

}
