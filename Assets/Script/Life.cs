using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Life : MonoBehaviour
{
        // Start is called before the first frame update
        public int MAXLife=3;
        public static int Damege=0;
        public Sprite lifepicture;
        GameObject[] newlife=new GameObject[3];
        public static bool lifeswich=false;
        //int[] array = new int[3];
        void Start()
        {
                Damege=0;
                //Damege=MAXLife;
                //Debug.Log("Screen Width : " + Screen.width);
                //Debug.Log("Screen  height: " + Screen.height);
                //Debug.Log(lifepicture.bounds.size);
                for(int i=0; i<MAXLife; i++) {
                        newlife[i]=new GameObject( "Life" );
                        newlife[i].transform.localScale = new Vector3(0.2f, 0.2f, 1); //大きさを調整
                        newlife[i].transform.localPosition = new Vector3(-4, i, 1); //大きさを調整
                        var sr=newlife[i].AddComponent<SpriteRenderer>();
                        sr.sprite=lifepicture;
                }
        }
        // Update is called once per frame
        void Update()
        {
                if(lifeswich==true) {
                        for(int i=0; i<Damege; i++) {
                                //Debug.Log(Damege);
                                Destroy(newlife[i]);
                                lifeswich=false;
                        }
                }
                if(MAXLife==Damege) {
                        //gameover
                        //Debug.Log(Damege);
                        Score.ranking_swich=true;
                        SceneManager.LoadScene ("Title");
                }
        }
}
