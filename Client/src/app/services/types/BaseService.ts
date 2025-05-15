import { inject, signal } from '@angular/core';
import IPaginatedSearchRequest from './IPaginatedSearchRequest';
import { IPaginatedResponse } from './IPaginatedResponse';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { finalize } from 'rxjs';

export default class ServiceBase<T> {
  apiRoute: string = '';
  get baseUrl(): string {
    return `${environment.apiUrl}/${this.apiRoute}`;
  }
  newUrls: any = {
    create: null,
    update: null,
    delete: null,
    getAll: null,
    getById: null,
    getPage: null,
  };

  get urls() {
    return {
      create: this.newUrls.create ?? this.baseUrl,
      update: this.newUrls.update ?? this.baseUrl,
      delete: this.newUrls.delete ?? this.baseUrl,
      getAll: this.newUrls.getAll ?? this.baseUrl,
      getById: this.newUrls.getById ?? this.baseUrl,
      getPage: this.newUrls.getPage ?? this.baseUrl + `/page`,
    };
  }

  pageConfig: IPaginatedSearchRequest = {
    pageSize: 10,
    pageNumber: 1,
    searchTerm: '',
    orderBy: 'id',
  };

  page = signal<IPaginatedResponse<T>>({
    totalCount: 0,
    pageSize: 0,
    pageNumber: 0,
    totalPages: 0,
    hasPrevious: false,
    hasNext: false,
    items: [],
  });

  httpClient = inject(HttpClient);

  getPage(searchRequest: IPaginatedSearchRequest = this.pageConfig) {
    this.pageConfig = searchRequest;

    // this.checkLoading();
    // console.log(`${this.urls.getPage}?`);
    return this.httpClient
      .get(
        `${this.urls.getPage}?` +
          `pageNumber=${this.pageConfig?.pageNumber ?? 1}&` +
          `pageSize=${this.pageConfig?.pageSize ?? 10}&` +
          `searchTerm=${this.pageConfig?.searchTerm ?? ''}&` +
          `orderBy=${this.pageConfig?.orderBy ?? 'id'}`
      )
      .pipe(
        finalize(() => {
          console.log('finalized from base get page');
        })
      );
  }
}
