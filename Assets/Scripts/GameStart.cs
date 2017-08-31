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
            } catch (Exception e) {
                GameStartStatus.OnError(e);
            }
        }

        /// <summary>
        /// 内部処理
        /// </summary>
        private void exec() {
            GameStartStatus.OnNext("初期化完了");
        }
        #endregion

        /// <summary>
        /// ゲーム開始処理実行
        /// </summary>
        public void Generate() {
            init();
            exec();
            GameStartStatus.OnCompleted();
        }
    }

}