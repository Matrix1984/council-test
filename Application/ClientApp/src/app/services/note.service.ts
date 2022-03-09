import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Note } from '../types/note.type';
import { SatelliteRes } from '../types/satelite-res.type';
import { Satellite } from '../types/satellite.type';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  constructor(private http: HttpClient) {}

  public saveNote(body:any): Observable<Note> {
      const url = 'https://localhost:7159/api/Notes';
      return this.http.post<Note>(url,body); 
  }

  public listNotes(): Observable<Note[]> {
    const url = 'https://localhost:7159/api/Notes';
    return this.http.get<Note[]>(url);
  }
}
