declare global {
    interface Window {
        APP_CONFIG: {
            API_URL: string;
        };
    }
}

export const appConfig = {
    apiUrl: window.APP_CONFIG.API_URL
};