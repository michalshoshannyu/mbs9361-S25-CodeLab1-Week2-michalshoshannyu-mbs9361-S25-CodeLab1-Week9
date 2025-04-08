using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public LocationScriptableObject currentLocation;

    public TextMeshProUGUI title;
    public TextMeshProUGUI desc;

    public Button topButton;
    public Button bottomButton;
    public Button rightButton;
    public Button leftButton;

    public GameObject characterScene;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        // UpdateLocation();
        currentLocation.UpdateUI(this);
        
    }

    // Update is called once per frame
    public void SpanChar(GameObject prefab)
    {
        if (characterScene != null)
        {
            characterScene.SetActive(false);
            characterScene = null;
        }

        if (prefab != null)
        {
            characterScene = Instantiate(prefab);
            characterScene.SetActive(true);
        }
    }
    
    public void MoveDir(int dir)
    {
        switch (dir)
        {
            case 0:
                //set all the possible path to led to the same place?
                currentLocation = currentLocation.top;
                break;
            case 1:
                currentLocation = currentLocation.left;
                break;
            case 2:
                currentLocation = currentLocation.bottom;
                break;
            case 3:
                currentLocation = currentLocation.right;
                break;
            default:
                Debug.Log("Invalid Direction" + dir + "not implemented");
                break;
        };  
        currentLocation.UpdateUI(this);
    }

}
