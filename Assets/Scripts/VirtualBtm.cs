using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualBtm : MonoBehaviour
{
    public Rooms roomToGO;

    GameManager _gm;
    private SpriteRenderer _sprite;
    Vector3 _defaultScale;
    TextMesh _title;
    private RoomPicture _parent;
    public void SetGM(GameManager gm)
    {
        _gm = gm;
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.color = _gm.defaultColor;
        _defaultScale = transform.localScale;
        _title = GetComponentInChildren<TextMesh>();
        _title.color = _gm.defaultColor;
        _title.gameObject.SetActive(false); ;
        _parent = transform.parent.GetComponent<RoomPicture>();
    }
    private void OnMouseDown()
    {
        _sprite.color = _gm.clickedColor;
        _title.color = _gm.selectedColor;
        _gm.ChangeRoom(roomToGO);
        _parent.ShowHideArrows(false);
    }
    private void OnMouseEnter()
    {
        _sprite.color = _gm.selectedColor;
        transform.localScale = _defaultScale * 1.25f;
        _title.color = _gm.selectedColor;
        _title.gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        _sprite.color = _gm.defaultColor;
        transform.localScale = _defaultScale;
        _title.color = _gm.defaultColor;
        _title.gameObject.SetActive(false); ;
    }
}

