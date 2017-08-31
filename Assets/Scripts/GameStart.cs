using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

namespace MainGame {
    public class GameStart : MonoBehaviour {

        #region 変数管理
        public Subject<string> GameStartStatus { get; set; }
        [SerializeField] private Image fadePanel;
        [SerializeField] private Color startColor;
        [SerializeField] private Color endColor;
        [SerializeField] private float waitFadeTime = 2.0f;
        #endregion

        #region 基本処理
        /// <summary>
        /// 初期化処理
        /// </summary>
        private void init() {
            // new Instance
            try {
                GameStartStatus = new Subject<string>();
                GameStartStatus.OnNext("初期化開始");
                StartCoroutine(exec());
            } catch (Exception e) {
                GameStartStatus.OnError(e);
            }
        }

        /// <summary>
        /// 内部処理
        /// </summary>
        private IEnumerator exec() {

            #region フェードインフェードアウト処理
            yield return null;
            fadePanel.color = startColor;
            yield return null;
            // フェードアウト
            DOTween.To(
                () => fadePanel.color,
                color => fadePanel.color = color,
                endColor,
                waitFadeTime
                );
            yield return new WaitForSeconds(waitFadeTime + 0.1f);

            fadePanel.gameObject.SetActive(false);
            #endregion

            GameStartStatus.OnNext("初期化完了");
        }

        
        #endregion

        /// <summary>
        /// ゲーム開始処理実行
        /// </summary>
        public void Generate() {
            init();
            GameStartStatus.OnCompleted();
        }
    }

}