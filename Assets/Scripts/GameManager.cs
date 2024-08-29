using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public enum Rooms { Foto1, Foto2, Foto3, Foto4, Foto5, Foto6, Foto7, Foto8 }
public class GameManager : MonoBehaviour
{
    [Header("Colores de los eventos en botones")]
    public Color selectedColor, defaultColor, clickedColor;

    [Header("Selector de Habitacion")]
    public Rooms startRoom;

    [Header("UI Settings")]
    public Text title;
    public GameObject canvas;

    private GameObject[] _arrayRooms;
    private String[] _arrayRoomTitle = { "Inicio", "Centro", "GranRoca", "Arboles", "Escampada", "El Cactus", "Monticulos", "Volver al Inicio" };
    private float _inc, _counter;
    void Start()
    {
        _arrayRooms = new GameObject[Enum.GetValues(typeof(Rooms)).Length];
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void AddRoomToArray(GameObject go, Rooms room)
    {
        _arrayRooms[(int)room] = go;
        _arrayRooms[(int)room].SetActive(room == startRoom);       
        title.text = _arrayRoomTitle[(int)startRoom];
    }
    public void ChangeRoom(Rooms roomToGo)
    {
        _counter = 0;
        _inc = Time.deltaTime;
        canvas.SetActive(false);
        StartCoroutine(ChangeRoomAfterTime(roomToGo));
    }
    private IEnumerator ChangeRoomAfterTime(Rooms roomToGo)
    {
        yield return new WaitForEndOfFrame();
        _counter += _inc;
        if (_counter > 1)
        {
            for (int i = 0; i < _arrayRooms.Length; i++)
            {
                _arrayRooms[i].SetActive(i == (int)roomToGo);
            }
            title.text = _arrayRoomTitle[(int)roomToGo];
            _inc = -Time.deltaTime;
            StartCoroutine(ChangeRoomAfterTime(roomToGo));
        }
        else if (_counter < 0)
        {
            canvas.SetActive(true);       
        }
        else
        {
            StartCoroutine(ChangeRoomAfterTime(roomToGo));
        }
        RenderSettings.ambientLight = Color.white * (1 - _counter) + Color.black * _counter;

    }
}
