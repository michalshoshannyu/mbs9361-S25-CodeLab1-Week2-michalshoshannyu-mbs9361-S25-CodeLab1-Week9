using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu
    (fileName = "LocationScriptableObject",
     menuName = "Scriptable Objects/LocationScriptableObject")
]

public class LocationScriptableObject : ScriptableObject
{
    public string locationName = "New Location";
    public string locationDesc = "Description";

    [FormerlySerializedAs("north")] public LocationScriptableObject top;
    public LocationScriptableObject bottom;
    public LocationScriptableObject left;
    public LocationScriptableObject right;
    
    [FormerlySerializedAs("characterScene")] 
    //public GameObject characterScene2;
    public List<GameObject> characterScene2;
    public void UpdateUI(GameManager gm)
    {

        GameObject choosePrefab = null;
        if (characterScene2 != null && characterScene2.Count > 0)
        {
            int index = Random.Range(0, characterScene2.Count);
            choosePrefab = characterScene2[index];
        }
        
        gm.SpanChar(choosePrefab);
        gm.title.text = locationName;
        gm.desc.text = locationDesc;

        if (top == null)
        {
            gm.topButton.gameObject.SetActive(false);
        }
        else
        {
            top.bottom = this;
            gm.topButton.gameObject.SetActive(true);
        }

        if (bottom == null)
        {
            gm.bottomButton.gameObject.SetActive(false);
        }
        else
        {
            bottom.top = this;
            gm.bottomButton.gameObject.SetActive(true);
        }

        if (left == null)
        {
            gm.leftButton.gameObject.SetActive(false);
        }
        else
        {
            left.right = this;
            gm.leftButton.gameObject.SetActive(true);
        }

        if (right == null)
        {
            gm.rightButton.gameObject.SetActive(false);
        }
        else
        {
            right.left = this;
            gm.rightButton.gameObject.SetActive(true);
        }

      
        //map out neighbors back to us
       
        // top.bottom = this;
        // bottom.top = this;
        // right.left = this;
        // left.right = this;
        //
    }
    
}
