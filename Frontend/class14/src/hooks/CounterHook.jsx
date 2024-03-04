import { useReducer } from "react";

const initialState = { count: 0 };

const actions = {
  INCREMENT: "INCREMENT",
  DECREMENT: "DECREMENT",
  RESET: "RESET",
};

const reducer = (state = initialState, action) => {
  switch (action.type) {
    case actions.INCREMENT:
      return { count: state.count + 1 };
    case actions.DECREMENT:
      return { count: state.count - 1 };
    case actions.RESET:
      return initialState;
    default:
      return state;
  }
};

export const useCounter = () => {
  const [state, dispatch] = useReducer(reducer, initialState);

  const increment = () => dispatch({ type: actions.INCREMENT });
  const decrement = () => dispatch({ type: actions.DECREMENT });
  const reset = () => dispatch({ type: actions.RESET });

  return { count: state.count, increment, decrement, reset };
};
