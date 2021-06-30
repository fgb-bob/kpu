import distinWin from './distinWin.js'

export default function distinWiner(player, check, hands){
    let win = distinWin(check, hands); //승리한 가위, 바위 , 보 확인
    let winner = [];

    for (let pl of player.keys()){
        if(player.get(pl) == win){
            winner.push(pl);
        }
    }
    console.log(`Winner: ${winner}`)
}