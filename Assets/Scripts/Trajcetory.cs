using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trajcetory : MonoBehaviour
{
    [SerializeField] private int amountOfDots;
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private float dotSpacing;

    private List<Transform> _dots;
    private Vector2 _position;
    private float _timeStamp;

    private static Trajcetory _instance;
    public static Trajcetory Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
    }
    
    private void Start()
    {
        Hide();
        PrepareDots();
    }

    private void PrepareDots()
    {
        _dots = new List<Transform>();
        for (int i = 0; i < amountOfDots; i++)
        {
            GameObject dot = Instantiate(dotPrefab, transform);
            _dots.Add(dot.transform);
        }
    }

    public void UpdateDots(Vector3 ballPos, Vector2 forceApplied)
    {
        _timeStamp = dotSpacing;
        for (int i = 0; i < amountOfDots; i++)
        {
            _position.x = (ballPos.x + forceApplied.x * _timeStamp);
            _position.y = (ballPos.y + forceApplied.y * _timeStamp) - (Physics2D.gravity.magnitude * _timeStamp * _timeStamp) / 2f;
            _dots[i].position = _position;
            _timeStamp += dotSpacing;
        }
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
}

