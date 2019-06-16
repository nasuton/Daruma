using UnityEngine;
using UnityEngine.UI;
using FancyScrollView;

public class MenuCell : FancyScrollViewCell<MenuItemData, Context>
{
    [SerializeField]
    Animator animator = null;

    [SerializeField]
    Text message = null;

    [SerializeField]
    Text messageLarge = null;

    [SerializeField]
    Image image = null;

    [SerializeField]
    Image imageLarge = null;

    [SerializeField]
    Button button = null;

    private float currentPos = 0.0f;

    static class AnimatorHash
    {
        public static readonly int Scroll = Animator.StringToHash("scroll");
    }

    private void Start()
    {
        //ボタンを押した際のイベントを登録
        button.onClick.AddListener(() => Context.OnCellClicked?.Invoke(Index));
    }

    //表示を更新する時に呼び出されます
    public override void UpdateContent(MenuItemData itemData)
    {
        message.text = itemData.Message;
        messageLarge.text = Index.ToString();

        var selected = Context.selectedIndex == Index;
        imageLarge.color = image.color = selected ? new Color32(0, 255, 255, 100) : new Color32(255, 255, 255, 77);
    }

    //位置を更新する際に呼び出される
    //Animatorを使用することでアニメーションを適用することも可能
    public override void UpdatePosition(float position)
    {
        currentPos = position;
        animator.Play(AnimatorHash.Scroll, -1, position);
        animator.speed = 0;
    }

    //GameObjectが非アクティブになるとAnimatorがリセットされるので
    //現在位置を保持しておいて、OnEnableのタイミングで現在位置を再設定する
    private void OnEnable() => UpdatePosition(currentPos);
}
