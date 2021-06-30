export default function drawHands(num, player, check, hands){

    for (let i = 0 ; i < num ; i++){
        let hand = Math.floor(Math.random()*3);
        player.set(`${i+1}P`, hands[hand]);
        check.add(hands[hand]); //가위, 바위 , 보 중 나온 것을 set에 추가. (중복 추가 x)
    }
    console.log(player.entries());
}