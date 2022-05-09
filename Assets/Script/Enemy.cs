using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
        // Start is called before the first frame update
        int Start_position=0;
        float Tile_Size;//タイルサイズ:メインから取得
        Vector2 middle_position;//中央の位置:メインから取得
        sokoban mainsystem;
        Vector2 Now_Positon;
        Rigidbody2D enemy_rigid;
        BoxCollider2D enemy_collider;
        void Start()
        {
                this.transform.localScale = new Vector3(0.2f, 0.2f, 1);//大きさを調整
                var mainsystem_get=GameObject.Find("Main_system");
                mainsystem=mainsystem_get.GetComponent<sokoban>();
                //colliderを付ける：あたり判定を付ける
                enemy_rigid=this.gameObject.AddComponent<Rigidbody2D>();
                //enemy_rigid=this.GetComponent<Rigidbody2D>();
                enemy_rigid.gravityScale=0;
                enemy_collider=this.gameObject.AddComponent<BoxCollider2D>();
                enemy_collider.isTrigger=true;
                //スポーン位置の設定
                Start_position=Random.Range(0,8);
                //スポーン場所の決定乱数
                //偶数はヨコ、奇数はタテ
                Tile_Size=mainsystem.tileSize;//メインからタイルサイズを取得
                middle_position=mainsystem.middleOffset;;
                // middle_position.x = 8 * Tile_Size * 0.5f - Tile_Size * 0.5f;
                // middle_position.y = 8 * Tile_Size * 0.5f - Tile_Size * 0.5f;
                if(Start_position%2==0) {
                        this.transform.position = GetDisplayPosition( 6,Start_position);
                }else{
                        this.transform.position = GetDisplayPosition( Start_position-1, 0 );
                }
                this.tag="Enemy";
        }

        // Update is called once per frame
        void Update()
        {
                Now_Positon=this.transform.position;//今の位置を取得
                if(Start_position%2==0) {
                        Now_Positon.x-=0.005f;
                }else{
                        Now_Positon.y-=0.005f;
                }
                transform.position=Now_Positon;
                if(Now_Positon.x<-2||Now_Positon.y<-2) {//ダメージを受ける
                        //Debug.Log("damege");
                        Life.Damege++;
                        Life.lifeswich=true;
                        Destroy(gameObject);
                }
        }
        private Vector2 GetDisplayPosition( int x, int y )
        {
                return new Vector2
                       (
                        x *  Tile_Size - middle_position.x,
                        y * -Tile_Size + middle_position.y
                       );
        }

        void OnTriggerEnter2D(Collider2D other){
                //Debug.Log(other.gameObject.tag); // ログを表示する
                if(other.gameObject.tag=="Enemy") return;
                if(other.gameObject.name=="player") {
                        Score.pointin=100;
                }else{
                        Score.pointin=500;
                }
                Destroy(this.gameObject);
        }
}
