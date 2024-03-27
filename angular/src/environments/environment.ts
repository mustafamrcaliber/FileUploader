import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'http://192.168.0.101:44377/',
  redirectUri: baseUrl,
  clientId: 'FileUploader_App',
  responseType: 'code',
  scope: 'offline_access FileUploader',
  requireHttps: false,
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
      url: 'http://192.168.0.101:44335',
      rootNamespace: 'FileUploader',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
