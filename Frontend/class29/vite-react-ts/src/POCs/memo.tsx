import React, { ReactNode, useMemo, useState, useEffect } from 'react'

const MemoComponent: React.FC = (): ReactNode => {
    const [shouldRecalculate, setShouldRecalculate] = useState<boolean>(false);

    const expensiveCalculation: string = useMemo<string>(() => {
        // Perform expensive calculation here
        // This calculation will only be 
        //re-executed if the dependencies change
        const random:number = Math.random()*100
        return ((42 ** 2) ** random).toString()
    }, [shouldRecalculate])


    // This useEffect will only run when the shouldRecalculate state changes
    useEffect(() => {
        if (shouldRecalculate) {
            setShouldRecalculate(false);
        }
    }, [shouldRecalculate]);

    const handleButtonClick = ():void => {
        console.log('%c%s', 'color: #e50000', "Just clicked the button");
        setShouldRecalculate(true);
    }

    return (
        <div>
            <h1>Memo Component</h1>
            <p>Expensive Calculation: {expensiveCalculation}</p>
            <button onClick={handleButtonClick} type="button" aria-label="recalculate">Recalculate</button>
        </div>
    )
}

export default MemoComponent


