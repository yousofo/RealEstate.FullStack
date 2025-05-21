// import { AppTheme } from '@lib/services/theme';

import { IAuthState } from "../../types/auth";

type StorageObjectMap = {
    appSession: {
        user: IAuthState['user'];
        token: string;
    };
    darkMode: boolean;
    // appTheme: AppTheme;
};

export type StorageObjectType = 'appSession'|'darkMode'; //| 'appTheme';

export type StorageObjectData<T extends StorageObjectType> = {
    type: T;
    data: StorageObjectMap[T];
};