import { storage } from './storage.utils';

describe('StorageUtils', () => {
    it('should clear all items from local & session storage', () => {
        // LocalStorage
        storage.clear();
        expect(localStorage.length).toBe(0);

        // sessionStorage
        storage.clear({ api: 'SessionStorage' });
        expect(localStorage.length).toBe(0);
    });
});