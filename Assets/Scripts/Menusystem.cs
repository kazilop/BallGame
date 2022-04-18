using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;


[System.Serializable]
public class MenuEntry
{
    public string EntryName;
    public UnityEvent Callback;
}

[RequireComponent(typeof(UIDocument))]

public class Menusystem : MonoBehaviour
{
    
    [SerializeField] private List<MenuEntry> _menus;
    [SerializeField] private float _buttonDelay;
    [SerializeField] private VisualTreeAsset _buttonTemplate;

    private VisualElement _container;
    private WaitForSeconds _pause;
    private int _moveDistance = 100;

    public void Start()
    {
        _pause = new WaitForSeconds(_buttonDelay);
        StartCoroutine(CreateMenu());
    }

    
    private IEnumerator CreateMenu()
    {
        _container = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>("menu-container");
        
        foreach(MenuEntry entry in _menus)
        {
            VisualElement newElement = _buttonTemplate.CloneTree();
            Button button = newElement.Q<Button>("menu-button");
            button.text = entry.EntryName;
            button.clicked += delegate { OnClick(entry); };
            _container.Add(newElement);

            newElement.style.transitionDuration = new List<TimeValue>() { new TimeValue(_buttonDelay, TimeUnit.Second) };
            
            newElement.style.marginTop = _moveDistance;
            yield return null;
            newElement.style.marginTop = 0;

            yield return _pause;
        }
    }

    private void OnClick(MenuEntry entry)
    {
        entry.Callback.Invoke();
    }
}
