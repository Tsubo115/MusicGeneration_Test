using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //Randomのため


public class GA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        main();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //コード進行に含まれるコードの数
    int M = 8;

    private void main(){
        //chord progression(度数)
        int[] cp = new int[M];
        
        //初期解生成
        initial(cp);

        for (int i = 0; i < 10; i++){
            GAmain(cp);
        }
    }

    //初期解生成
    private void initial(int[] cp){
        System.Random rand = new System.Random(); //オブジェクト生成
        
        for(int i = 0; i < M; i++){
            cp[i] = rand.Next(1,8); //1～7までの乱数を生成して代入
        }
    }

    private void GAmain(int[] cp){
    }
    
}
