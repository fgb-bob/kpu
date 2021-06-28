export function num_users(){
    return Math.floor(Math.random()*9+2);
}

export function assign_stat(array,num){
    for (let i = 0; i < num; i++) {
        array[i]=Math.floor(Math.random()*3);   
    }
    return array;
}

export function game_result(array,num){
    if(array.indexOf(0)==-1&&array.indexOf(1)!=-1&&array.indexOf(2)!=-1){
        console.log("보자기 승");
        for(let i=0;i<num;i++){
            if(array[i]==2){
                console.log(`${i+1} 번 플레이어가 이겼습니다.`);
            }
        }
    }

    else if(array.indexOf(1)==-1&&array.indexOf(0)!=-1&&array.indexOf(2)!=-1){
        console.log("가위 승");
        for(let i=0;i<num;i++){
            if(array[i]==0){
                console.log(`${i+1} 번 플레이어가 이겼습니다.`);
            }
        }
    }

    else if(array.indexOf(2)==-1&&array.indexOf(0)!=-1&&array.indexOf(1)!=-1){
        console.log("바위 승");
        for(let i=0;i<num;i++){
            if(array[i]==1){
                console.log(`${i+1} 번 플레이어가 이겼습니다.`);
            }
        }
    }
    else if(array.indexOf(0)==-1&&array.indexOf(1)==-1){
        console.log("비겼습니다");
        let n = Math.floor(Math.random()*4+1);
        console.log(`${n} 초 후 다시 시작합니다`);
        sleep(n*1000).
        then(()=>game_restart(array));
    }
    else if(array.indexOf(1)==-1&&array.indexOf(2)==-1){
        console.log("비겼습니다");
        let n = Math.floor(Math.random()*4+1);
        console.log(`${n} 초 후 다시 시작합니다`);
        sleep(n*1000).
        then(()=>game_restart(array));
    }
    else if(array.indexOf(3)==-1&&array.indexOf(0)==-1){
        console.log("비겼습니다");
        let n = Math.floor(Math.random()*4+1);
        console.log(`${n} 초 후 다시 시작합니다`);
        sleep(n*1000).
        then(()=>game_restart(array));
    }
    else {
        console.log("비겼습니다");
        let n = Math.floor(Math.random()*4+1);
        console.log(`${n} 초 후 다시 시작합니다`);
        sleep(n*1000).
        then(()=>game_restart(array));
    }
}
export function game_restart(array){
    array_clear(array);
    game_start(array);
}

export default function game_start(array){
    let num=num_users();
    //console.log(num);
    array=assign_stat(array,num);
    display_user(array,num);
    game_result(array,num);
}

export function array_clear(array){
    for(let i=array.length;i>0;i--){
        array.pop();
    }
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
export function sleep(ms) {
    return new Promise((r) => setTimeout(r, ms));
}
