import { useRef } from 'react';

function RefComponent() {
    const inputRef = useRef<HTMLInputElement | null>(null);

    const handleClick = () => {
        if (inputRef.current) {
            inputRef.current.focus();
        }
    };

    return (
        <div>
            <label htmlFor="inputField">Input Field:</label>
            <input ref={inputRef} type="text" id="inputField" title="Input Field" placeholder="Enter text" />
            <button onClick={handleClick}>Focus Input</button>
        </div>
    );
}

export default RefComponent



