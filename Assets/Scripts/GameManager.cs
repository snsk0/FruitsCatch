using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FruitsCatchEvents;
using UniRx;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //各オブジェクト
    [Header("GameObjects")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private PlayerController player;
    [SerializeField] private ObjectCatcher catcher;
    [SerializeField] private FruitsGenerator generator;
    [SerializeField] private FruitsGenerator stoneGenerator;

    //各パラメータ
    [Header("Parameter")]
    [SerializeField] private float limitTime;
    [SerializeField] private List<GameParameter> phases = new List<GameParameter>();

    //UI
    [Header("UI")]
    [SerializeField] private Transform canvas;
    [SerializeField] private Text scoreText;
    [SerializeField] private Image clockGauge;
    [SerializeField] private Text HightScore;
    [SerializeField] private Button ReturnButton;

    //演出
    [Header("Perform")]
    [SerializeField] private Text countDown;
    [SerializeField] private Text appleScore;
    [SerializeField] private Text stoneScore;


    //内部パラメータ
    private GameParameter phase;
    private float delta;
    private float passed;
    private int score;


    private int count;


    void Start()
    {
        //イベント登録
        catcher.OnCatch.Subscribe(e => OnCatchObjectEvent((FCCatchObjectEvent)e));

        delta = 0;
        passed = 0;
        phase = phases[0];
        score = 0;

        count = 3;
    }

    void Update()
    {
        if (count != 0)
        {
            TextFadeOut fade = countDown.GetComponent<TextFadeOut>();
            if (fade.end)
            {
                count--;
                countDown.text = count.ToString();
                fade.ReStart();
            }
            return;
        }

        delta += Time.deltaTime;    //時間を経過
        passed += Time.deltaTime;

        if (passed > limitTime)
        {
            Debug.Log("aaa");
            HightScore.gameObject.SetActive(true);
            ReturnButton.gameObject.SetActive(true);
            return;
        }

        phase = phases[(int)(passed / (limitTime / phases.Count))];  //フェーズを確定

        //インターバルを過ぎたら
        if (delta > phase.interval)
        {
            delta -= phase.interval;

            //フルーツを生成
            switch (phase.getFruitsType())
            {
                case FruitsType.APPLE:
                    generator.FruitsGenerate();
                    break;
                case FruitsType.STONE:
                    stoneGenerator.FruitsGenerate();
                    break;
            }
        }
        clockGauge.fillAmount = 1.0f - (passed / limitTime);
    }


    //キャッチ
    private void OnCatchObjectEvent(FCCatchObjectEvent e)
    {
        switch (e.ca.type)
        {
            case FruitsType.APPLE:
                score += 3;
                Text text = Instantiate(appleScore);
                text.transform.SetParent(canvas);
                text.transform.position = mainCamera.WorldToScreenPoint(catcher.transform.position);
                break;
            case FruitsType.STONE:
                score -= 1;
                if (score < 0) score = 0;
                Text text2 = Instantiate(stoneScore);
                text2.transform.SetParent(canvas);
                text2.transform.position = mainCamera.WorldToScreenPoint(catcher.transform.position);
                break;
        }
        scoreText.text = "SCORE: " + score;
    }
}
