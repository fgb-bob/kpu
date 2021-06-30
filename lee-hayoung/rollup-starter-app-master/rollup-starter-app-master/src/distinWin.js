export default function distinWin(check, hands){
    let win="";

    for (let i = 0 ; i < hands.length ; i++){
        if(!check.has(hands[i]) && i < 2){
            win = hands[i+1];
        }
        else if(!check.has(hands[i]) && i == 2){ 
            win = hands[0] ;
        }
    }
    console.log(`\n${win} WIN!`);
    return win;
}