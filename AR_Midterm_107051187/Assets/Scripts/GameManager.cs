using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 註解:說明
    // 定義欄位: 儲存資料
    // 語法:
    // 修飾詞 類型 名稱;
    // 私人 private (預設)  - 不會顯示在屬性面板
    // 公開 public          - 會顯示在屬性面板
    // C# 支援中文
    // 欄位標題
    // 語法: [Header("文字訊息")]
    // () [] {} '' ""
    [Header("流氓")]
    public Transform male;
    [Header("殭屍")]
    public Transform zombie;
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("旋轉速度"), Range(0.1f, 20f)]
    public float turn = 1.5f;
    [Header("縮放"), Range(0f, 5f)]
    public float size = 0.3f;
    [Header("流氓動畫元件")]
    public Animator aniMale;
    [Header("殭屍動畫元件")]
    public Animator aniZombie;
    
    //事件:在特定時間會執行的區塊(名稱為藍色)
    //開始事件: 遊戲開始執行一次 - 初始設定
    private void Start()
    {
        print("開始事件");  
    }

    //public float test = 1;
    //public float test2 = 1;
    
    //更新事件: 遊戲每個影格會執行一次
    //一秒60格(60FPS)
    //一秒執行 約60次
    //控制物件移動、旋轉、縮放或玩家輸入
    private void Update()
    {
        print("更新事件");
        print(joystick.Vertical);   //虛擬搖桿 的 垂直資訊，float 浮點數 有小數點的數值

        male.Rotate(0, joystick.Horizontal * turn, 0); //殭屍.旋轉(0，虛擬搖桿的水平，0);
        zombie.Rotate(0, joystick.Horizontal * turn, 0);

        // += 累加(遞增)
        male.localScale += new Vector3(1, 1, 1) * joystick.Vertical * size;                      // 流氓.區域尺寸 = 新 三維向量(1，1，1) * 虛擬搖桿的垂直
        male.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(male.localScale.x, 0.5f, 3.5f);    // 流氓.區域尺寸 = 新 三維向量(1，1，1) * 數學.夾住(流氓的X，最小，最大)
        zombie.localScale += new Vector3(1, 1, 1) * joystick.Vertical * size;
        zombie.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(male.localScale.x, 0.5f, 3.5f);
        //test = Mathf.Clamp(test, 0.5f, 9.9f);
        //print(Mathf.Clamp(test2, 0, 10));
    }

    // 定義方法 Method
    // 定義程式區塊
    // 語法:
    // 修飾詞 類型 名稱 () { 程式區塊 }
    // 要給按鈕呼叫必須設為公開 public
    // 無類型 void
    public void Attack()
    {
        print("攻擊");
        aniZombie.SetTrigger("攻擊");
        aniMale.SetTrigger("攻擊");
    }

    // 修飾詞 類型 名稱 (參數1，參數2，......參數N) { 程式區塊 }
    // 參數語法: 類型 名稱
    public void PlayAnimation(string aniName)
    {
        print(aniName);
        aniZombie.SetTrigger(aniName);
        aniMale.SetTrigger(aniName);
    }
}
