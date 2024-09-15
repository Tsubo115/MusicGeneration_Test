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
        rank[0] = 50;
        rank[1] = 20;
        rank[2] = 20;
        rank[3] = 10;
        main(rank);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //オブジェクト生成
    System.Random r = new System.Random();

    //練習曲の数(子の作成方法により偶数のみ)
    int M = 4;
    //コード進行に含まれるコードの数
    int N = 8;


    //メイン
    private void main(int[] rank){
        //chord progression(度数のみ，M行N列)
        int[,] cp = new int[M, N];
        
        //初期解生成
        initial(cp);

        //for (int i = 0; i < 10; i++){
        GAmain(rank, cp);
        //}
    }


    //初期解生成
    private void initial(int[,] cp){
        for(int i = 0; i < M; i++){ //練習曲数回す
            for(int j = 0; j < N; j++){ //コード数回す
                cp[i, j] = r.Next(1,8); //1～7までの乱数を生成して代入
            }
        }
    }


    //GA部分
    private void GAmain(int[] rank, int[,] cp){
        //子
        int[,] cpCH = new int[M, N];

        //選択により選ばれる親
        int[] pa_num = new int[2];
        
        for(int i = 0; i < M; i += 2){ //i：何番目の子を作るか
            //ルーレット方式
            Roulette(rank, pa_num);

            //一点交叉
            Crossover(cp, cpCH, pa_num, i);
        } 

    }


    //ルーレット方式
    private void Roulette(int[] rank, int[] pa_num){
        int judge = 1; //同じ親が選ばれないためのフラグ, 実行 = 1 / 終了 = 0
        int sum = 0;
        int rand1, rand2;

        //違う親が選ばれるまで繰り返す
        while(judge == 1){
            judge = 0;
            
            //評価の合計を計算
            for(int i = 0; i < M; i++){
                sum += rank[i];
            }

            rand1 = r.Next(1,sum);
            rand2 = r.Next(1,sum);

            //親1の決定
            sum = 0;
            for(int i = 0; i < M; i++){
                sum += rank[i];
                if(rand1 <= sum){
                    pa_num[0] = i;
                    break;
                }
            }

            //親2の決定
            sum = 0;
            for(int i = 0; i < M; i++){
                sum += rank[i];
                if(rand2 <= sum){
                    pa_num[1] = i;
                    break;
                }
            }

            //同じ親が選ばれた場合　フラグ = 1
            if(pa_num[0] == pa_num[1]){
                judge = 1;
            }
        }
    }


    //一点交叉
    private void Crossover(int[,] cp, int[,] cpCH, int[] pa_num, int a){
        int rand = r.Next(0,N); //0～(N-1)までの乱数
        
        //親1をもとに子1を作る, 親2をもとに子2を作る
        for(int i = 0; i < N; i++){ //rまでは元親の情報
            if(i == rand){
                break;
            }
            cpCH[a, i] = cp[pa_num[0], i];
            cpCH[a + 1, i] = cp[pa_num[1], i];
        }
        for(int i = rand; i < N; i++){ //r以降はすべて別親の情報
            cpCH[a, i] = cp[pa_num[1], i];
            cpCH[a + 1, i] = cp[pa_num[0], i];
        }
    }
    
}
