using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //Randomのため


public class GA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //評価
        int[] rank = new int[M];
        main(rank);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //練習曲の数
    int M = 4;
    //コード進行に含まれるコードの数
    int N = 8;


    //メイン
    private void main(int[] rank){
        //chord progression(度数のみ，M行N列)
        int[,] cp = new int[M, N];
        
        //初期解生成
        initial(cp);

        for (int i = 0; i < 10; i++){
            GAmain(rank, cp);
        }
    }


    //初期解生成
    private void initial(int[,] cp){
        System.Random rand = new System.Random(); //オブジェクト生成
        
        for(int i = 0; i < M; i++){ //練習曲数回す
            for(int j = 0; j < N; j++){ //コード数回す
                cp[i, j] = rand.Next(1,8); //1～7までの乱数を生成して代入
            }
        }
    }


    //GA部分
    private void GAmain(int[] rank, int[,] cp){
        //子
        int[,] cpCH = new int[M, N];

        //選択により選ばれる親
        int pa1, pa2;
        
        for(int i = 2; i < M; i += 2){
            //ルーレット方式
            Roulette(rank, ref pa1, ref pa2);
        }

    }

    //ルーレット方式
    private void Roulette(int[] rank, int pa1, int pa2){
        int judge = 1; //同じ親が選ばれないためのフラグ
        int sum = 0;
        int rand1, rand2;

        //違う親が選ばれるまで繰り返す
        while(judge == 1){
            judge = 0;
            
            //評価の合計を計算
            for(int i = 0; i < M; i++){
                sum += rank;
            }

            rand1 = rand.Next(1,sum);
            rand2 = rand.Next(1,sum);

            sum = 0;

            for(int i = 0; i < M; i++){
                ;
            }
        }
    }
    
}
