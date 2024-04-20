import  { useRef, useImperativeHandle, forwardRef } from 'react';

type Marcus = HTMLDivElement & { doSomething: () => void, doSomethingElse: () => void };

// Child component
const ChildComponent = forwardRef((props, ref) => {
    const childRef = useRef<Marcus | null>(null);

    // Expose a function to the parent component
    useImperativeHandle(ref, () => ({
        // Function that can be called from the parent component
        doSomething: () => {
            console.log('Child component did something');
        },
        // Function that can be called from the parent component
        doSomethingElse: () => {
            console.log('Child component did something else');
        }
    }));

    return <div>Child Component {JSON.stringify(childRef)}</div>;
});

// Parent component
const ParentComponent = () => {
    const childRef = useRef<Marcus | null>(null);

    const handleClick = () => {
        // Call the exposed function from the child component
        childRef.current!.doSomethingElse();
    };

    return (
        <div>
            <ChildComponent ref={childRef} />
            <button onClick={handleClick}>Call Child Component</button>
        </div>
    );
};

export default ParentComponent;


