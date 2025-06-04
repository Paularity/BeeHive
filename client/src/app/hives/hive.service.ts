import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Hive {
  hiveId: string;
  location: string;
  hiveName: string;
  queenAge: number;
  colonyStrength: number;
  healthStatus: string;
}

@Injectable({ providedIn: 'root' })
export class HiveService {
  private baseUrl = '/api/hives';

  constructor(private http: HttpClient) {}

  getHives(status?: string): Observable<Hive[]> {
    let params = new HttpParams();
    if (status && status !== 'all') {
      params = params.set('status', status);
    }
    return this.http.get<Hive[]>(this.baseUrl, { params });
  }
}
