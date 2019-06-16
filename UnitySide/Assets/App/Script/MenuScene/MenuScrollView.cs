using EasingCore;
using FancyScrollView;
using System.Collections.Generic;
using UnityEngine;

public class MenuScrollView : FancyScrollView<MenuItemData, Context>
{
    [SerializeField]
    Scroller scroller = null;

    [SerializeField]
    GameObject cellPerfab = null;

    protected override GameObject CellPrefab => cellPerfab;

    private void Awake()
    {
        Context.OnCellClicked = SelectCell;
    }

    private void Start()
    {
        scroller.OnValueChanged(UpdatePosition);
        scroller.OnSelectionChanged(UpdateSelection);
    }

    private void UpdateSelection(int index)
    {
        if(Context.selectedIndex == index)
        {
            return;
        }

        Context.selectedIndex = index;
        Refresh();
    }

    public void UpdateData(IList<MenuItemData> items)
    {
        UpdateContents(items);
        scroller.SetTotalCount(items.Count);
    }

    public void SelectCell(int index)
    {
        if(index < 0 || ItemsSource.Count <= index || index == Context.selectedIndex)
        {
            return;
        }

        UpdateSelection(index);
        scroller.ScrollTo(index, 0.35f, Ease.OutCubic);
    }
}
