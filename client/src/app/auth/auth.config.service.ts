import { Injectable } from '@angular/core';
import { AuthClientConfig, AuthConfig } from '@auth0/auth0-angular';

@Injectable({ providedIn: 'root' })
export class AuthConfigService {
  constructor(private config: AuthClientConfig) {}

  load(): void {
    const authConfig: AuthConfig = {
      domain: window.env.AUTH0_DOMAIN,
      clientId: window.env.AUTH0_CLIENT_ID,
      authorizationParams: {
        audience: window.env.AUTH0_AUDIENCE,
      },
      useRefreshTokens: true,
      cacheLocation: 'localstorage'
    };
    this.config.set(authConfig);
  }
}
