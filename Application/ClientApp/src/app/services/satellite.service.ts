import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SatelliteRes } from '../types/satelite-res.type';

@Injectable({
  providedIn: 'root'
})
export class SatelliteService {

  constructor(private http: HttpClient) {}

  public getInfo(): Observable<SatelliteRes> {
      const url = 'https://localhost:7159/SateliteCoordinates';
      return this.http.get<SatelliteRes>(url);
  }
  
}
