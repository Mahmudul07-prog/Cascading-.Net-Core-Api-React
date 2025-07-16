
// src/services/LocationService.ts
import type { Country, Division, City } from '../Models/LocationModels';

const API_BASE_URL = 'http://localhost:5178/api/Locations';

export const LocationService = {
  async getCountries(): Promise<Country[]> {
    const response = await fetch(`${API_BASE_URL}/countries`);
    if (!response.ok) throw new Error('Failed to fetch countries');
    return await response.json();
  },

  async getDivisions(countryId: number): Promise<Division[]> {
    const response = await fetch(`${API_BASE_URL}/divisions/${countryId}`);
    if (!response.ok) throw new Error('Failed to fetch divisions');
    return await response.json();
  },

  async getCities(divisionId: number): Promise<City[]> {
    const response = await fetch(`${API_BASE_URL}/cities/${divisionId}`);
    if (!response.ok) throw new Error('Failed to fetch cities');
    return await response.json();
  },

  async getAllLocations(): Promise<{
    countries: Country[];
    divisions: Division[];
    cities: City[];
  }> {
    const response = await fetch(`${API_BASE_URL}/all`);
    if (!response.ok) throw new Error('Failed to fetch all locations');
    return await response.json();
  },
};