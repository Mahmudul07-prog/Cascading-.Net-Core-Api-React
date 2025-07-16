import React from 'react';
import './App.css';
import LocationDropdowns from './components/LocationDropdowns';
import './components/LocationDropdowns.css';


const App: React.FC = () => {
    return (
        <div className="App">
            <h1>Location Selector</h1>
            <LocationDropdowns />
        </div>
    );
};


export default App;