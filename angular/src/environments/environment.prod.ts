import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44324/',
  redirectUri: baseUrl,
  clientId: 'AbpPoc_App',
  responseType: 'code',
  scope: 'offline_access AbpPoc',
  requireHttps: true,
  impersonation: {
    tenantImpersonation: true,
    userImpersonation: true,
  }
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'AbpPoc',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44324',
      rootNamespace: 'AbpPoc',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
  remoteEnv: {
    url: '/getEnvConfig',
    mergeStrategy: 'deepmerge'
  }
} as Environment;
