export interface Country {
    id: number;
    name: string;
    divisions?: Division[]; // Optional for navigation
}

export interface Division {
    id: number;
    name: string;
    countryId: number;
    country?: Country; // Optional for navigation
    cities?: City[]; // Optional for navigation
}

export interface City {
    id: number;
    name: string;
    divisionId: number;
    division?: Division; // Optional for navigation
}