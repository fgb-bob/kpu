//import update from './update.js';

// even though Rollup is bundling all your files together, errors and
// logs will still point to your original source modules
//console.log('if you have sourcemaps enabled in your devtools, click on main.js:5 -->');

function wait(msecs)
{
    var start = new Date().getTime();
    var cur = start;
    while(cur - start < msecs)
    {
        cur = new Date().getTime();
    }
}

const hands = ['rock', 'sissor', 'paper']
let player_num = Math.floor(Math.random() * 9) + 2; //2~10 난수생성
const player = new Map();
const check = new Set();
player_num=2;
console.log(`${player_num}명의 플레이어\n`)
let game = 1;
while(true){
    
    for (let i = 0 ; i < player_num ; i++){
        let hand = Math.floor(Math.random()*3)
        player.set(`${i+1}P`, hands[hand])
        check.add(hands[hand]) //가위, 바위 , 보 중 나온 것을 set에 추가. (중복 추가 x)
    }
    console.log(player.entries());
    player.clear()

    if(check.size == 2) break;  //가위, 바위, 보 중 두 가지만 나왔을 때
    check.clear();

    console.log(`${game++}번째 게임, 무승부\n`)

    wait(Math.floor(Math.random()*1000)+2000); //2~3초 간격으로 돌린다.

}

let win=""

for (let i = 0 ; i < hands.length ; i++){
    if(!check.has(hands[i]) && i < 2){
        win = hands[i+1]
    }
    else if(!check.has(hands[i]) && i == 2){ 
        win = hands[0] 
    }
}
console.log(`${win} WIN!\n`)

//update();
