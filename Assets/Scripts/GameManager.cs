using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private CardController m_CardPrefab; //カードの型となるプレハブの情報(プレハブフォルダからインスペクターにドラッグ)
    [SerializeField] private Transform m_PlayerHandTransform; //プレイヤーのハンドの位置の情報(ヒエラルキーからドラッグ&ドロップ)

    [SerializeField] private BattleManager m_BattleManager; //BatteManager.csの関数を持ってくるために宣言
    [SerializeField] private EnemyManager m_EnemyManager; //ヒエラルキーにスクリプトをアタッチしたGameObjectを作り、アタッチする
    
    [SerializeField] private List<int> m_CemeteryPredCardList = new List<int>();//手札に来たカードを次のターンに墓地に入れるためのリスト
    [SerializeField] private Transform[] m_RefreshArea;//ターン終了時に掃除するカード群

    private bool m_TurnEndFlg = false;

    //【超重要】カードIDのリストをstatic宣言 いずれDataBaseみたいなのに移す
    public static List<int> s_AllCardList = new List<int>();//全カード管理
    public static List<int> s_DeckCardList = new List<int>();//現在のデッキにあるカード
    public static List<int> s_CemeteryCardList = new List<int>();//現在の墓地にあるカード

    //DeckViewManagerでも使うのでstatic宣言
    public static bool s_DeckCheck = false; //デッキを確認したかどうかを記録しておく
    public static bool s_CemeteryCheck = false; //墓地を確認したかどうかを記録しておく

    //
    public static bool s_BattleEnd = false;

    //BattleManagerでも使うのでstatic宣言　いずれDataBaseみたいなのに移す
    public static int s_PlayerHP = 50; //プレイヤーの最大HP情報
    public static int s_EnemyHP = 10; //敵の最大HP情報

    //BattleManagerでも使うのでstatic宣言　いずれDataBaseみたいなのに移す
    public static int s_EnemyATK; //敵の攻撃
    public static int s_EnemyMAT; //敵の魔法攻撃

    //現在はテスト中なので、起動したらすぐにカードが生成されるようになっている
    void Awake()
    {
        s_DeckCardList.Add(1);
        s_DeckCardList.Add(2);
        s_DeckCardList.Add(3);
        s_DeckCardList.Add(1);
        s_DeckCardList.Add(2);
        s_DeckCardList.Add(3);
        s_DeckCardList.Add(1);
        s_DeckCardList.Add(2);
        s_DeckCardList.Add(3);

        StartCoroutine(GameLoop());
    }

    //ターンエンドボタンが押されたら
    public void OnClickTurnEndButton()
    {
        m_TurnEndFlg = true;
    }

    //退出ボタンが押されたら
    public void OnClickExitButton()
    {
        SceneManager.LoadScene("Exploration");

    }


    private IEnumerator GameLoop()
    {
        m_TurnEndFlg = false;

        yield return StartCoroutine(StartPlayerTurn());

        yield return StartCoroutine(SetStartHand());

        yield return new WaitWhile(() => !m_TurnEndFlg);

        yield return StartCoroutine(EndPlayerTurn());

        if (s_BattleEnd == true)
        {
            yield break;
        }
        else
        {
            StartCoroutine(GameLoop());
        }

    }

    private IEnumerator StartPlayerTurn()
    {
        m_EnemyManager.DecideEnemyBehavior();//EnemyManager内の敵の行動を決める関数
        m_BattleManager.StartTurn();//BattleManagerの起動
        yield return null;
    }

    private IEnumerator SetStartHand()
    {
        ShuffleCards();//カードシャッフル
        //カード生成
        for (int i = 0; i < 3; i++)
        {
            CreateCard(m_PlayerHandTransform); //同じスクリプト内のCreateCard()を実行
        }
        yield return null;
    }

    private IEnumerator EndPlayerTurn()
    {
        m_BattleManager.CalcDamage();
        RefreshPhase();
        yield return null;
    }


    //カードを生成する関数
    void CreateCard(Transform hand)
    {
        CardController m_Card = Instantiate(m_CardPrefab, hand, false); //hand位置にカードプレハブからカードを生成し、CardController型の変数m_cardとする

        if (s_DeckCardList.Count == 0)
        {
            //山札が無くなったら墓地をデッキに戻してシャッフル
            s_DeckCardList.AddRange(s_CemeteryCardList); //デッキの中身に墓地のカードを足し
            s_CemeteryCardList.Clear(); //墓地のカードをクリアし
            ShuffleCards(); //シャッフルを行う
        }
        m_Card.Init(s_DeckCardList[0]); //CardController.cs内のInit(引数)を実行　カードのIDから生成
        m_CemeteryPredCardList.Add(s_DeckCardList[0]);//今生成したカードを墓地予定リストに入れる
        s_DeckCardList.RemoveAt(0);//今生成したカードをデッキのリストから抜く
    }

    //カードが置かれている場所をクリアする
    void RefreshPhase()
    {
        for (int i = 0; i < 5; i++)
        {
            foreach (Transform child in m_RefreshArea[i])
            {
                Destroy(child.gameObject);//Transformの方が上位の概念なの！？？！？
            }
        }
        s_CemeteryCardList.AddRange(m_CemeteryPredCardList);
        m_CemeteryPredCardList.Clear();
        s_DeckCheck = false;
        s_CemeteryCheck = false;


    }


    //デッキをシャッフルする
    void ShuffleCards() 
    {
        // 整数 n の初期値はデッキの枚数
        int n = s_DeckCardList.Count;

        // nが1より小さくなるまで繰り返す
        while (n > 1)
        {
            n--;

            // kは 0 ～ n+1 の間のランダムな値
            int k = UnityEngine.Random.Range(0, n + 1);

            // k番目のカードをtempに代入
            int temp = s_DeckCardList[k];
            s_DeckCardList[k] = s_DeckCardList[n];
            s_DeckCardList[n] = temp;
        }
    }

}
