using System.Linq;
using UnityEngine;

public class MenuScroller : MonoBehaviour
{
    [SerializeField]
    private MenuScrollView scrollView = null;

    
    void Start()
    {
        var items = Enumerable.Range(0, 20)
            .Select(i => new MenuItemData($"Cell {i}"))
            .ToArray();

        scrollView.UpdateData(items);
        scrollView.SelectCell(0);
    }
}
