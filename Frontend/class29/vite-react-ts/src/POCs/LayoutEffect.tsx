// import { useLayoutEffect, useRef } from 'react';

// const LayoutEffectComponent: React.FC = () => {
//     const ref = useRef<HTMLDivElement>(null);

//     useLayoutEffect(() => {
//         // Perform layout-related side effects here
//         const element = ref.current;
//         if (element) {
//             // Access and modify the DOM element
//             element.style.backgroundColor = 'red';
//             element.style.color = 'white';
//         }
//     }, []);

//     //flickering  || layout jumping

//     return <div ref={ref}>Example Component</div>;
// };

// export default LayoutEffectComponent;






import { useLayoutEffect, useRef, useState } from 'react';

const LayoutEffectComponent: React.FC = () => {
    const ref = useRef<HTMLDivElement>(null);
    const [trigger, setTrigger] = useState(false);

    useLayoutEffect(() => {
        const element = ref.current;
        if (element) {
             element.style.backgroundColor = 'red';
            element.style.color = 'white';
        }
        if(trigger)
            element!.style.backgroundColor = 'yellow', element!.style.color = 'black';
    }, [trigger]);

    return (
        <div>
            <div ref={ref}>Example Component</div>
            <button onClick={() => setTrigger(!trigger)}>Trigger Layout Effect</button>
        </div>
    );
};

export default LayoutEffectComponent;


