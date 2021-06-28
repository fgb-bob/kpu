const a = 1;
const b = 'Wow';
const sayYeah = () => {
  //alert('Yeah'); 
  console.log('Yeah');
};
const object2 = {
  sayHello() {
    //alert('hello');
    console.log('hello');
  },
  sayYeah,
  [a + 3]: 'four', // 4: 'four'
  ['say' + b]() {
    //alert('Wow');
    console.log('Wow');
  }  // sayWow() { alert('Wow') }
};

console.log(object2);

console.log(object2.sayYeah());

console.log('');

const object3 = {
    name: 'Zero',
    friends: ['One', 'Two', 'Three'],
    alertFriends() {     
      this.friends.forEach((friend) => {
        //alert(this.name + ' and ' + friend);
        console.log(this.name + ' and ' + friend);
      });
    }
  };
  object3.alertFriends();

  console.log('');

  var func = function(msg='hello') {
    console.log(msg);
  };
  func();

  const func4 = (x, ...y) => {
    console.log(y.length);
  };
  func4(1, 2, 3, 4) 

var array = [1, 2, 3];
var func5 = function(x, y, z) {
  //alert(x + y + z);
  console.log(x + y + z);
};

func5(...array);

console.log('');

class Human {
    constructor(type = 'human') {
      this.type = type;
    }
  
    static isHuman(human) {
      return human instanceof Human;
    }
  
    breathe() {
      //alert('h-a-a-a-m');
      console.log('h-a-a-a-m');
    }
  }
  
  class Zero extends Human {
    constructor(type, firstName, lastName) {
      super(type);
      this.firstName = firstName;
      this.lastName = lastName;
    }
  
    sayName() {
      super.breathe();
      //alert(`${this.firstName} ${this.lastName}`);
      console.log(`${this.firstName} ${this.lastName} ${this.type}`);
    }
  }
  
  const newZero = new Zero('human', 'Zero', 'Cho');
  Human.isHuman(newZero); // true
  console.log(Human.isHuman(newZero));
  console.log(newZero.sayName());

  console.log('');

  const [c, ,d] = [1, 2, 3];
  console.log(c); // 1
  console.log(d); // 3

  const obj2 = {
    h: 'Eich',
    i: {
      j: 'Jay'
    },
    k: 'un'
  }
  const { h, i: { j }, k } = obj2;
  console.log(h, j, k); // 'Eich', 'Jay', undefined

  console.log('');

  const destruct = ({ value: x }) => {
    console.log(x);
   };
   const arg = { value: 3 };
   destruct(arg); // 3
   
for (var i in 'string') { /*alert(i);*/ console.log(i); } // 0, 1, 2, 3, 4, 5
for (var i of 'string') { /*alert(i);*/ console.log(i); } // s, t, r, i, n, g
let array2 = [3, 5, 7];
array.foo = 'bar';
for (let j in array2) { /*alert(j);*/ console.log(i); } // 0, 1, 2, foo
for (let j of array2) { /*alert(j);*/ console.log(i); } // 3, 5, 7

var map = new Map([['zero', 'ZeroCho']]);
map.set('hero', 'Hero');
map.get('zero'); // 'ZeroCho'
map.size; // 2
map.has('hero'); // true
map.has('nero'); // false
map.entries(); // {['zero', 'ZeroCho'], ['hero', 'Hero']}
console.log(map.entries());
map.keys(); // {'zero', 'hero'}
console.log(map.keys());
map.values(); // {'ZeroCho', 'Hero'}
console.log(map.values());
map.delete('hero');
map.clear();

let factorial = {
    [Symbol.iterator]() {
      let count = 1;
      let cur = 1;
      return {
        next() {
          [count, cur] = [count + 1, cur * count];
          return { done: false, value: cur };
        }
      }
    }
  };
  for (let n of factorial) {
    if (n > 10000000) {
      break;
    }
    console.log(n);
  } // 1, 2, 6, 24, 120, 720, 5040, 40320, ...

  function* factGenerator() {
    let cur = 1;
    let count = 1;
    while (true) {
      [count, cur] = [count + 1, cur * count]
      yield cur;
    }
  }
  let factGen = factGenerator();
  console.log(factGen.next().value); // 1
  console.log(factGen.next().value); // 2
  console.log(factGen.next().value); // 6
  console.log(factGen.next().value);
  console.log(factGen.next().value);
  console.log(factGen.next().value);
  console.log(factGen.next().value);

  function async(gen) {
  let iterator = gen();
  let result;
  (function iterate(val) {
    result = iterator.next(val); // yield에 값을 전달
    if (!result.done) { // iterator의 끝까지 반복
      if (result.value.then) { // result의 value가 promise 객체이면
        result.value.then(iterate); // promise의 then을 실행
      } else { // promise 객체가 아니면
        setTimeout(() => { // 비동기로
          iterate(result.value); // 다음 value를 yield로 보내서 처리
        }, 0);
      }
    }
  })();
}

function* con(){
    let cur =1;
    while (true){
        cur = cur*2;
        yield cur;
    }
    
}

let funcon = con();
console.log(funcon.next().value);
console.log(funcon.next().value);
console.log(funcon.next().value);
console.log(funcon.next().value);
console.log(funcon.next().value);