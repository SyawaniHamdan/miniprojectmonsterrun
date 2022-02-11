using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconDisplayer : MonoBehaviour
{
    public GameObject IconPrefab;
    public List<Sprite> AllIcons = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        //spawn icons
        SpawnIcons();
    }

    void SpawnIcons()
    {
        for(int i =0; i< AllIcons.Count; i++)
        {
            GameObject _sprite = Instantiate(IconPrefab);
            _sprite.transform.parent = transform;
            _sprite.transform.localPosition = Vector3.zero;
            _sprite.transform.localEulerAngles = Vector3.zero;
            _sprite.transform.localScale = Vector3.one;

            _sprite.GetComponent<UnityEngine.UI.Image>().sprite = AllIcons[i];
            _sprite.name = AllIcons[i].name;

        }
    }

}
