import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import QuizComp from './Components/QuizComp';


const App = () => {
    const handleClick = async () => {
        try {
            const res = await fetch('task/taskData')
                .then(response => {
                    return response.json();
                })
                .then(data => {
                    console.log(data);
                })
        }
        catch(error) {
            console.log("error: ", error);
        }
    }
    return (
        <div>
            <QuizComp />
        </div>
    )
}

export default App;