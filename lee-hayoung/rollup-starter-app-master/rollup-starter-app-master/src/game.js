import wait from './wait.js'
import drawHands from './drawHands.js'
import distinWinner from './distinWinner.js'


export default function game(){
    const hands = ['rock', 'sissor', 'paper']
    const player = new Map();
    const check = new Set();
    let game = 1;

    const player_num = Math.floor(Math.random() * 9) + 2; //2~10 난수생성
    console.log(`${player_num}명의 플레이어\n`);

    while(true){
        
        drawHands(player_num, player, check, hands);

        if(check.size == 2) break;  //가위, 바위, 보 중 두 가지만 나왔을 때 중단
        
        player.clear();

        check.clear();
        console.log(`${game++}번째 게임, 무승부\n`);

        wait(Math.floor(Math.random()*1000)+2000); //2~3초 간격으로 돌린다.

    }

    distinWinner(player, check, hands)
    //승자 확인
}