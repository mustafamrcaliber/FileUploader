import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ExtraAppServicesService {
  apiName = 'Default';
  

  getUrlForIFrame = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>({
      method: 'GET',
      responseType: 'text',
      url: '/api/app/extra-app-services/url-for-iFrame',
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
