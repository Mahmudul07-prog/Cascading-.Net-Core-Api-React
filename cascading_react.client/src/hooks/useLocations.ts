import { useState, useEffect } from 'react';
import { LocationService } from '../services/LocationService';
import type { Country, Division, City } from '../Models/LocationModels';

export const useLocations = () => {
    const [countries, setCountries] = useState<Country[]>([]);
    const [divisions, setDivisions] = useState<Division[]>([]);
    const [cities, setCities] = useState<City[]>([]);
    const [selectedCountry, setSelectedCountry] = useState<number | null>(null);
    const [selectedDivision, setSelectedDivision] = useState<number | null>(null);
    const [selectedCity, setSelectedCity] = useState<number | null>(null);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    // Load initial countries
    useEffect(() => {
        const loadCountries = async () => {
            setIsLoading(true);
            try {
                const data = await LocationService.getCountries();
                setCountries(data);
                setError(null);
            } catch (err) {
                setError(err instanceof Error ? err.message : 'Failed to load countries');
            } finally {
                setIsLoading(false);
            }
        };

        loadCountries();
    }, []);

    // Load divisions when country changes
useEffect(() => {
    if (selectedCountry) {
        const loadDivisions = async () => {
            setIsLoading(true);
            try {
                const data = await LocationService.getDivisions(selectedCountry);

                setDivisions(data);
                setSelectedDivision(null); // Only reset after new data arrives
                setCities([]);
                setSelectedCity(null);
                setError(null);
            } catch (err) {
                setError(err instanceof Error ? err.message : 'Failed to load divisions');
            } finally {
                setIsLoading(false);
            }
        };

        loadDivisions();
    } else {
        setDivisions([]);
        setCities([]);
        setSelectedDivision(null);
        setSelectedCity(null);
    }
}, [selectedCountry]);

    // Load cities when division changes
    useEffect(() => {
        if (selectedDivision) {
            const loadCities = async () => {
                setIsLoading(true);
                try {
                    const data = await LocationService.getCities(selectedDivision);
                    setCities(data);
                    setSelectedCity(null); // Reset city on division change
                    setError(null);
                } catch (err) {
                    setError(err instanceof Error ? err.message : 'Failed to load cities');
                } finally {
                    setIsLoading(false);
                }
            };

            loadCities();
        } else {
            setCities([]);
            setSelectedCity(null);
        }
    }, [selectedDivision]);

    return {
        countries,
        divisions,
        cities,
        selectedCountry,
        selectedDivision,
        selectedCity,
        isLoading,
        error,
        setSelectedCountry,
        setSelectedDivision,
        setSelectedCity,
    };
};