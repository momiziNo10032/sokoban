using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking_call : MonoBehaviour
{
        // Start is called before the first frame update
        void Start()
        {
                Debug.Log("Score.ranking_swich:"+Score.ranking_swich);
                if(Score.ranking_swich==true) {
                        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (Score.point);
                }

        }

        // Update is called once per frame
        void Update()
        {

        }
}
