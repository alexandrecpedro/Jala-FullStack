import React from "react";
import { useCounter } from "../hooks/CounterHook";
import Counter from "../molecules/Counter";

const CounterPage = () => {
  const { count, increment, decrement, reset } = useCounter();
  return (
    <>
      <h1>Use Reducer</h1>
      <Counter
        count={count}
        onIncrement={increment}
        onDecrement={decrement}
        onReset={reset}
      ></Counter>
    </>
  );
};

export default CounterPage;
