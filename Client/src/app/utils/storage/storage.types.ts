// import { AppTheme } from '@lib/services/theme';

import { IAuthState } from "../../types/auth";

type StorageObjectMap = {
    appSession: {
        user: IAuthState['user'];
        token: string;
    };
    // appTheme: AppTheme;
};

export type StorageObjectType = 'appSession'; //| 'appTheme';

export type StorageObjectData<T extends StorageObjectType> = {
    type: T;
    data: StorageObjectMap[T];
};