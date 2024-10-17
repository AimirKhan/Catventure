using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Services.WebRequest;
using UI.main.Item;
using UnityEngine;
using UnityEngine.UIElements;

public class CafeUI : MonoBehaviour
{
    public VisualTreeAsset itemsListTemplate;

    private List<Item> items = new();
    private ListView itemsListView;
    private Button okButton;
    private UIDocument uiDocument;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        // List
        // 1. Initialize list of products
        items.Add(new Item() { Name = "Пирожок", Price = 40 });
        items.Add(new Item() { Name = "Мороженое", Price = 60 });
        items.Add(new Item()
        {
            Name = "Самса", Price = 57, Uri = "https://i65.shop/upload/iblock/83f/py6xzdlrrulrmob8lz6cvv9wxtto1jdg.jpg"
        });

        // 2. Link ListView
        itemsListView = uiDocument.rootVisualElement.Q<ListView>("list");

        // 3. Link template elements with ListView
        itemsListView.makeItem = () => itemsListTemplate.Instantiate();

        // 4. Link datas with ListView
        itemsListView.bindItem = async (_item, _index) =>
        {
            // Link Price List by index
            var item = items[_index];
            // Granted access to VisualElements template by Name, which we'd set in template
            _item.Q<Label>("Name").text = item.Name;
            _item.Q<Label>("Price").text = $"{item.Price} руб.";
            // Image files should be located Resources folder and named as product name
            if (!string.IsNullOrEmpty(item.Uri))
            {
                _item.Q<VisualElement>("Image").style.backgroundImage =
                    await DownloadImageHandler.Instance.DownloadTextureCoroutine(item.Uri);
            }
            else
            {
                _item.Q<VisualElement>("Image").style.backgroundImage = Resources.Load<Texture2D>(item.Name);
            }
        };

        // Link items with ListView
        itemsListView.itemsSource = items;

        // 5. RegisterCallbacks from List
        itemsListView.selectionChanged += ItemsListViewOnSelectionChange;
    }

    private void ItemsListViewOnSelectionChange(IEnumerable<object> obj)
    {
        if (obj.Count() > 0)
        {
            var item = obj.First() as Item;
            Debug.Log(item.Name + ": " + item.Price + " руб.");
        }
    }
}