using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_maneger : MonoBehaviour
{
        public Sprite[] m_enemyPrefabs; // 敵のプレハブを管理する配列
        //public float m_interval; // 出現間隔（秒）
        private float m_timer; // 出現タイミングを管理するタイマー
        public float m_intervalFrom; // 出現間隔（秒）（ゲームの経過時間が 0 の時）
        public float m_intervalTo; // 出現間隔（秒）（ゲームの経過時間が m_elapsedTimeMax の時）
        public float m_elapsedTimeMax; // 経過時間の最大値
        public float m_elapsedTime; // 経過時間
        private int enemy_count=0;//敵の出現数
        // 毎フレーム呼び出される関数
        private void Update()
        {
                // // 出現タイミングを管理するタイマーを更新する
                // m_timer += Time.deltaTime;
                //
                // // まだ敵が出現するタイミングではない場合、
                // // このフレームの処理はここで終える
                // if ( m_timer < m_interval ) return;
                // 経過時間を更新する
                m_elapsedTime += Time.deltaTime;

                // 出現タイミングを管理するタイマーを更新する
                m_timer += Time.deltaTime;

                // ゲームの経過時間から出現間隔（秒）を算出する
                // ゲームの経過時間が長くなるほど、敵の出現間隔が短くなる
                var t = m_elapsedTime / m_elapsedTimeMax;
                var interval = Mathf.Lerp( m_intervalFrom, m_intervalTo, t );

                // まだ敵が出現するタイミングではない場合、
                // このフレームの処理はここで終える
                if ( m_timer < interval ) return;

                // 出現タイミングを管理するタイマーをリセットする
                m_timer = 0;

                // 出現する敵をランダムに決定する
                var enemyIndex = Random.Range( 0, m_enemyPrefabs.Length );
                // 出現する敵のプレハブを配列から取得する
                var enemyPrefab = m_enemyPrefabs[ enemyIndex ];

                //敵の出現設定
                enemy_count++;
                var enemy_name="enemy:"+enemy_count;//敵の名前
                var enemy=new GameObject(enemy_name); //敵の生成
                enemy.AddComponent<Enemy>();
                var sr=enemy.AddComponent<SpriteRenderer>();
                sr.sprite=enemyPrefab;
                sr.sortingOrder = 2;
                // 敵のゲームオブジェクトを生成する
                //var enemy = Instantiate( enemyPrefab );
                // 敵を初期化する
                //enemy.Init( respawnType );
        }
}
