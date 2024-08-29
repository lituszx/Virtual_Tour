using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPicture : MonoBehaviour
{
    public Rooms room;
    private GameManager _gm;
    // Start is called before the first frame update
    void Start()
    {
        _gm = transform.GetComponentInParent<GameManager>();
        _gm.AddRoomToArray(gameObject, room);
        foreach (VirtualBtm item in transform.GetComponentsInChildren<VirtualBtm>())
        {
            item.SetGM(_gm);
        }
    }
    public void ShowHideArrows(bool show)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(show);
        }
    }
    private void OnEnable()
    {
        StartCoroutine(RestoreArrows());
    }
    IEnumerator RestoreArrows()
    {
        yield return new WaitForSeconds(1f);
        ShowHideArrows(true);
    }
}
