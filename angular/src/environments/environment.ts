import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44377/',
  redirectUri: baseUrl,
  clientId: 'FileUploader_App',
  responseType: 'code',
  scope: 'offline_access FileUploader',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'FileUploader',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44335',
      rootNamespace: 'FileUploader',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
