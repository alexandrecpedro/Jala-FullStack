import { useState, useEffect, ReactNode } from 'react';

const EffectComponent = ():ReactNode => {
    const [result1, setResult1] = useState<string>('');
    const [result2, setResult2] = useState<string>('');
    const [result3, setResult3] = useState<string>('');
    const [dependency, setDependency] = useState<string>('');

    useEffect(() => {

        console.log('%c%s', 'color: #733d00', 'Component updated only when the screen is refreshed');
        setResult1(`Component updated only when the screen is refreshed - ${new Date().toLocaleTimeString()}`);
    }, []);

    useEffect(() => {
        console.log("No restrictions");
        setResult2(`Component rendered as needed - ${new Date().toLocaleTimeString()}`);
    });

    useEffect(() => {
        console.log('Dependency changed');
        setResult3(`Component updated when the "dependency" variable changes: ${dependency} - ${new Date().toLocaleTimeString()}`);
    }, [dependency]);

    return (
        <div style={{ margin: '20px 20px 20px 20px' }}>
            <button onClick={() => setResult1('')}>Update Result 1</button>
            <button onClick={() => setResult2('')}>Update Result 2</button>
            <button onClick={() => setDependency('Value Changed')}>Update Result 3</button>

            <div>Result 1: {result1}</div>
            <div>Result 2: {result2}</div>
            <div>Result 3: {result3}</div>
        </div>
    );
};

export default EffectComponent;