// src/hooks/useAllLocations.ts
import { useState, useEffect } from 'react';
import { LocationService } from '../services/LocationService';
import type { Country, Division, City } from '../Models/LocationModels';

export const useAllLocations = () => {
    const [allData, setAllData] = useState<{
        countries: Country[];
        divisions: Division[];
        cities: City[];
    } | null>(null);
    const [selectedCountry, setSelectedCountry] = useState<number | null>(null);
    const [selectedDivision, setSelectedDivision] = useState<number | null>(null);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const loadAllData = async () => {
            setIsLoading(true);
            try {
                const data = await LocationService.getAllLocations();
                setAllData(data);
                setError(null);
            } catch (err) {
                setError(err instanceof Error ? err.message : 'Failed to load locations');
            } finally {
                setIsLoading(false);
            }
        };

        loadAllData();
    }, []);

    // Filter divisions based on selected country
    const filteredDivisions = selectedCountry
        ? allData?.divisions.filter((d) => d.countryId === selectedCountry) || []
        : [];

    // Filter cities based on selected division
    const filteredCities = selectedDivision
        ? allData?.cities.filter((c) => c.divisionId === selectedDivision) || []
        : [];

    return {
        countries: allData?.countries || [],
        divisions: filteredDivisions,
        cities: filteredCities,
        selectedCountry,
        selectedDivision,
        isLoading,
        error,
        setSelectedCountry,
        setSelectedDivision,
    };
};