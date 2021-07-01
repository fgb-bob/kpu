export default function num_users(){
    return Math.floor(Math.random()*9+2);
}

export function assign_stat(array,num){
    for (let i = 0; i < num; i++) {
        array[i]=Math.floor(Math.random()*3);   
    }
    return array;
}

export function display_user(array,num){
    for(let i=0;i<num;i++){
        if(array[i]==0){
            console.log(`${i+1} 번 플레이어 : 가위`)
        }
        else if(array[i]==1){
            console.log(`${i+1} 번 플레이어 : 바위`)
        }
        else if(array[i]==2){
            console.log(`${i+1} 번 플레이어 : 보`)
        }
        else {
            console.log("에러");
        }
    }
}

export function array_clear(array){
    for(let i=array.length;i>0;i--){
        array.pop();
    }
}