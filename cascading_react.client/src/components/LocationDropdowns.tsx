import React from 'react';
import { useLocations } from '../hooks/useLocations';

const LocationDropdowns: React.FC = () => {
    const {
        countries = [], // Provide default empty array
        divisions = [], // Provide default empty array
        cities = [], // Provide default empty array
        selectedCountry,
        selectedDivision,
        selectedCity,
        isLoading,
        error,
        setSelectedCountry,
        setSelectedDivision,
        setSelectedCity
    } = useLocations();

    if (error) {
        return <div className="error-message">Error: {error}</div>;
    }

    return (
        <div className="location-dropdowns">
            <div className="dropdown-group">
                <label htmlFor="country">Country:</label>
                <select
                    id="country"
                    value={selectedCountry || ''}
                    onChange={(e) => setSelectedCountry(Number(e.target.value))}
                    disabled={isLoading}
                >
                    <option value="">Select a country</option>
                    {Array.isArray(countries) && countries.map((country) => (
                        <option key={country.id} value={country.id}>
                            {country.name}
                        </option>
                    ))}
                </select>
            </div>

            <div className="dropdown-group">
                <label htmlFor="division">Division:</label>
                <select
                    id="division"
                    value={selectedDivision || ''}
                    onChange={(e) => setSelectedDivision(Number(e.target.value))}
                    disabled={!selectedCountry || isLoading}
                >
                    <option value="">Select a division</option>
                    {Array.isArray(divisions) && divisions.map((division) => (
                        <option key={division.id} value={division.id}>
                            {division.name}
                        </option>
                    ))}
                </select>
            </div>

            <div className="dropdown-group">
                <label htmlFor="city">City:</label>
<select
    id="city"
    disabled={!selectedDivision || isLoading}
    value={selectedCity || ''}
    onChange={e => setSelectedCity(Number(e.target.value))}
>
    <option value="">Select a city</option>
    {Array.isArray(cities) && cities.map((city) => (
        <option key={city.id} value={city.id}>
            {city.name}
        </option>
    ))}
</select>
            </div>

            {isLoading && <div className="loading-indicator">Loading...</div>}
        </div>
    );
};

export default LocationDropdowns;