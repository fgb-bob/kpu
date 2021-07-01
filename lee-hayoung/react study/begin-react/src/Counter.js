//import React, { useReducer } from 'react';
import React, { Component } from 'react';

//함수형
/*
function reducer(state, action) {
    switch (action.type) {
      case 'INCREMENT':
        return state + 1;
      case 'DECREMENT':
        return state - 1;
      default:
        return state;
    }
  }

function Counter(){
    const [number, dispatch] = useReducer(reducer, 0);
    //const [number, setNumber]=useState(0);
    const onIncrease = () =>{
        dispatch({ type: 'INCREMENT' });
    }
    const onDecrease = () =>{
        dispatch({ type: 'DECREMENT' });
    }
    return (
        <div>
            <h1>{number}</h1>
            <button onClick = {onIncrease}>+1</button>
            <button onClick = {onDecrease}>-1</button>
        </div>
    );
}*/ 
//클래스형
/*
class Counter extends Component{
    render(){
        return(
            <div>
                <h1>0</h1>
                <button>+1</button>
                <button>-1</button>
    
            </div>
        );
   }
}*/

class Counter extends Component {

    /*
    constructor(props) { 
        super(props);
        this.handleIncrease = this.handleIncrease.bind(this);
        this.handleDecrease = this.handleDecrease.bind(this);
        // 메서드들을 각 button 들의 이벤트로 등록하게 되는 과정에서 각 메서드와 컴포넌트 인스턴스의 관계가 끊겨버리기 때문에 bind 해줌
      // bind 를 사용하면, 해당 함수에서 가르킬 this 를 직접 설정해줄 수 있다. 아니면 화살표 함수 사용
      
        this.state={
            counter:0
        };
      } */

      state={ 
          counter:0
      };


    handleIncrease = () => {
        this.setState({
            counter:this.state.counter +1
        }, ()=>{ //setState를 한다고 바로 상태가 바뀌지 않음. 바뀐 이후 작업하곳 ㅣ다면 두번쨰 파라미터에 
            console.log(this.state.counter)
        });
      
        //console.log(this)
    }
  
    handleDecrease = () => {
        this.setState({
            counter:this.state.counter -1
        }, ()=>{ //setState를 한다고 바로 상태가 바뀌지 않음. 바뀐 이후 작업하곳 ㅣ다면 두번쨰 파라미터에 
            console.log(this.state.counter);
        });
      
    }
  
    render() {
      return (
        <div>
          <h1>{this.state.counter}</h1>
          <button onClick={this.handleIncrease}>+1</button>
          <button onClick={this.handleDecrease}>-1</button>
        </div>
      );
    }
  }
  

export default Counter;