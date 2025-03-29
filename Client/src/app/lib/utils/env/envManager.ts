import { environment } from "../../../../environments/environment";

const env = {
    apiUrl: environment.apiUrl || process.env['API_URL'] ,
    geminiAiKey: environment.geminiAiKey || process.env['GEMINI_AI_KEY'] || '',
};

export function getEnv(key: 'apiUrl' | 'geminiAiKey'): string {
    return env[key]!;
}